using System;

namespace _9Concurency.BankingSystem
{
    public class AccountWithLock
    {
        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }

        private readonly object _balanceLock = new object();

        public AccountWithLock(int userNumber, string firstName, string lastName, double userBalance = 0)
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

            lock (_balanceLock)
            {
                var newBalance = this.UserBalance + amount;
                this.UserBalance = newBalance;
            }

            return true;
        }

        public Boolean Withdraw(double amount)
        {
            lock (_balanceLock)
            {
                if (amount < 0 || amount > this.UserBalance)
                {
                    return false;
                }

                var newBalance = this.UserBalance - amount;
                this.UserBalance = newBalance;

                return true;
            }
        }
    }
}
