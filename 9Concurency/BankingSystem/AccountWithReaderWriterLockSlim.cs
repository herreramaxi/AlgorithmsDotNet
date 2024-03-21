using System;
using System.Threading;

namespace _9Concurency.BankingSystem
{
    public class AccountWithReaderWriterLockSlim
    {
        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }
        private readonly ReaderWriterLockSlim _balanceLock = new ReaderWriterLockSlim();

        public AccountWithReaderWriterLockSlim(int userNumber, string firstName, string lastName, double userBalance = 0)
        {
            this.UserNumber = userNumber;
            this.UserFirstName = firstName;
            this.UserLastName = lastName;
            this.UserBalance = userBalance;
        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            _balanceLock.EnterWriteLock();

            try
            {
                var newBalance = this.UserBalance + amount;
                this.UserBalance = newBalance;


            }
            finally
            {
                _balanceLock.ExitWriteLock();
            }

            return true;
        }

        public Boolean Withdraw(double amount)
        {
            _balanceLock.EnterWriteLock();

            try
            {
                if (amount < 0 || amount > this.UserBalance)
                {
                    return false;
                }

                var newBalance = this.UserBalance - amount;
                this.UserBalance = newBalance;
            }
            finally
            {
                _balanceLock.ExitWriteLock();
            }

            return true;
        }
    }
}
