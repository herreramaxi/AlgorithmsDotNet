using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace _9Concurency.BankingSystem
{
    public class AccountProtectedByChannels : IAccount
    {
        private readonly Channel<double> _transactionChannel = Channel.CreateBounded<double>(1);

        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }

        private readonly Task _workerTask;

        public double UserBalance { get; private set; }

        public AccountProtectedByChannels(int userNumber, string firstName, string lastName, double userBalance = 0)
        {
            this.UserNumber = userNumber;
            this.UserFirstName = firstName;
            this.UserLastName = lastName;
            this.UserBalance = userBalance;
            _workerTask = StartWorker();
        }

        public bool Deposit(double amount)
        {
            return DepositAsync(amount).Result;
        }

        public async Task<bool> DepositAsync(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            await _transactionChannel.Writer.WriteAsync(amount);
            return true;
        }

        public bool Withdraw(double amount)
        {
            return WithdrawAsync(amount).Result;
        }

        public async Task<bool> WithdrawAsync(double amount)
        {
            if (amount <= 0 || amount > this.UserBalance)
            {
                return false;
            }

            await _transactionChannel.Writer.WriteAsync(-amount);
            return true;
        }

        private async Task StartWorker()
        {
            await foreach (double transactionAmount in _transactionChannel.Reader.ReadAllAsync())
            {
                UserBalance += transactionAmount;
            }
        }
    }
}