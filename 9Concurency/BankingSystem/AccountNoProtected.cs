﻿using System;

namespace _9Concurency.BankingSystem
{
    public class AccountNoProtected: IAccount
    {
        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }

        public AccountNoProtected(int userNumber, string firstName, string lastName, double userBalance = 0 )
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

            var newBalance = this.UserBalance + amount;
            this.UserBalance = newBalance;

            return true;
        }

        public Boolean Withdraw(double amount)
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
