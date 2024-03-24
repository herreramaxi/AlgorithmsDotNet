using System;

namespace _9Concurency.BankingSystem
{
    public interface IAccount
    {
        public int UserNumber { get;  }
        public string UserFirstName { get; }
        public string UserLastName { get;  }
        public double UserBalance { get; }

        public bool Deposit(double amount);
        public Boolean Withdraw(double amount);
    }
}
