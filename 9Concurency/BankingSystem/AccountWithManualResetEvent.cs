using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _9Concurency.BankingSystem
{
    public class AccountWithManualResetEvent: IAccount
    {
        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }

        private readonly ManualResetEvent _balanceLock = new ManualResetEvent(true); // Initially set to true (signaled)

        public AccountWithManualResetEvent(int userNumber, string firstName, string lastName, double userBalance = 0)
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

            _balanceLock.WaitOne(); // Wait until the event is signaled

            try
            {
                var newBalance = this.UserBalance + amount;
                this.UserBalance = newBalance;
            }
            finally
            {
                _balanceLock.Set(); // Set the event to signaled state
            }

            return true;
        }

        public Boolean Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            _balanceLock.WaitOne(); // Wait until the event is signaled

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
                _balanceLock.Set(); // Set the event to signaled state
            }

            return true;
        }
    }
}