namespace _9Concurency.BankingSystem
{
    public enum AccountType
    { 
        NoProtected = 0,
        Channels = 1,
        AutoResetEvent,
        ManualResetEvent,
        Lock,
        ReaderWriterLockSim,
        SemaphoreSlim

    }
}
