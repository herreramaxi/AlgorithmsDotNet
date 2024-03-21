using System.Threading.Channels;
using System.Threading.Tasks;

namespace _9Concurency.BankingSystem
{
    public class AccountProtected
    {
        private readonly Channel<double> transactionChannel = Channel.CreateBounded<double>(1);
        private double userBalance;

        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }

        public AccountProtected(int userNumber, string firstName, string lastName, double userBalance = 0)
        {
            this.UserNumber = userNumber;
            this.UserFirstName = firstName;
            this.UserLastName = lastName;

            // Set initial balance
            this.userBalance = userBalance;
        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            transactionChannel.Writer.TryWrite(amount);
            return true;
        }

        public async Task<bool> Withdraw(double amount)
        {
            if (amount <= 0 || amount > await GetUserBalance())
            {
                return false;
            }

            transactionChannel.Writer.TryWrite(-amount);
            return true;
        }

        public async Task<double> GetBalance()
        {
            if (transactionChannel.Reader.TryRead(out var _))
            {
                // Process pending transactions
                userBalance = await GetUserBalance();
            }

            return userBalance;
        }

        private async Task<double> GetUserBalance()
        {
            double balance = userBalance;
            await foreach (var transaction in transactionChannel.Reader.ReadAllAsync())
            {
                balance += transaction;
            }
            return balance;
        }
    }
}