using System;

namespace _9Concurency.BankingSystem
{
    public class AccountFactory
    {
        public static IAccount Create(AccountType accountType, int userNumber, string firstName, string lastName, double userBalance = 0)
        {

            switch (accountType)
            {
                case AccountType.NoProtected: return new AccountNoProtected(userNumber, firstName, lastName, userBalance);
                case AccountType.Channels: return new AccountProtectedByChannels(userNumber, firstName, lastName, userBalance);
                case AccountType.AutoResetEvent: return new AccountWithAutoResetEvent(userNumber, firstName, lastName, userBalance);
                case AccountType.ManualResetEvent: return new AccountWithManualResetEvent(userNumber, firstName, lastName, userBalance);
                case AccountType.Lock: return new AccountWithLock(userNumber, firstName, lastName, userBalance);
                case AccountType.ReaderWriterLockSim: return new AccountWithReaderWriterLockSlim(userNumber, firstName, lastName, userBalance);
                case AccountType.SemaphoreSlim: return new AccountWithSemaphoreSlim(userNumber, firstName, lastName, userBalance);
                default: throw new NotImplementedException();
            }
        }
    }
}
