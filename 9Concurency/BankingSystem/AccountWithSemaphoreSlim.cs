using System;
using System.Threading;

namespace _9Concurency.BankingSystem
{
    public class AccountWithSemaphoreSlim: IAccount
    {
        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }

        private readonly SemaphoreSlim _balanceLock = new SemaphoreSlim(1, 1); // initial count is 1, maximum count is 1

        public AccountWithSemaphoreSlim(int userNumber, string firstName, string lastName, double userBalance = 0)
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

            _balanceLock.Wait();

            try
            {
                var newBalance = this.UserBalance + amount;
                this.UserBalance = newBalance;
            }
            finally
            {
                _balanceLock.Release();
            }

            return true;
        }

        public Boolean Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            _balanceLock.Wait();

            try
            {
                if (amount > this.UserBalance)
                {
                    return false;
                }

                var newBalance = this.UserBalance - amount;
                this.UserBalance = newBalance;
            }
            finally
            {
                _balanceLock.Release();
            }

            return true;
        }
    }
}