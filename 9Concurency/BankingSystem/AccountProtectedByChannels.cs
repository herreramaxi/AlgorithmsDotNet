using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace _9Concurency.BankingSystem
{
    public class AccountProtectedByChannels
    {
        private readonly Channel<double> transactionChannel = Channel.CreateBounded<double>(1);

        public int UserNumber { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public double UserBalance { get; private set; }

        public AccountProtectedByChannels(int userNumber, string firstName, string lastName, double userBalance = 0)
        {
            this.UserNumber = userNumber;
            this.UserFirstName = firstName;
            this.UserLastName = lastName;
            this.UserBalance = userBalance;

            // Start the background processing for transactions
            ProcessTransactions();
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

        public bool Withdraw(double amount)
        {
            if (amount < 0 || amount > this.UserBalance)
            {
                return false;
            }

            transactionChannel.Writer.TryWrite(-amount);
            return true;
        }

        private async void ProcessTransactions()
        {
            await foreach (var transaction in transactionChannel.Reader.ReadAllAsync())
            {
                // Apply the transaction
                UserBalance += transaction;
            }
        }
    }
}