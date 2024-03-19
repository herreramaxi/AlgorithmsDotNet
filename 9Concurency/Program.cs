namespace _9Concurency
{
    using Serilog;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var logFileName = $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(logFileName, rollingInterval: RollingInterval.Day)
                 .CreateLogger();

            //ProducerConsumerNoProtected();
            //ProducerConsumerUsingLockAndMonitor();
            //ProducerConsumerDataFlow();

            //var producerConsumer  = new ProducerConsumerDirector(ProducerConsumerType.NoProtected, 1, 2,100);
            //var producerConsumer = new ProducerConsumerDirector(ProducerConsumerType.LockAndMonitor, 2, 2, 100);
            //var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.Dataflow, 4, 4, 10000);
            var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.Channel, 2, 2, 1000);
            producerConsumer.Run();
        }

        private static void ProducerConsumerDataFlow()
        {
            //var buffer = new BufferBlock<int>();
            //var producerConsumer = new ProducerConsumerDataflow(buffer);
            //var threads = new List<Thread>();
            //threads.Add(new Thread(() => Producer(producerConsumer)));
            //threads.Add(new Thread(() => Producer(producerConsumer)));
            //threads.Add(new Thread(() => Consumer(producerConsumer)));
            //threads.Add(new Thread(() => Consumer(producerConsumer)));

            //foreach (var item in threads)
            //{
            //    item.Start();
            //}
        }

        //public static void Log(string message)
        //{
        //    logger.Information($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        //    //logWriter.Flush(); // Ensure that the message is written immediately
        //}

        //private static void ProducerConsumerNoProtected()
        //{
        //    var producerConsumer = new ProducerConsumerNoProtected();
        //    var threads = new List<Thread>();
        //    threads.Add(new Thread(() => Producer(producerConsumer)));
        //    threads.Add(new Thread(() => Producer(producerConsumer)));
        //    threads.Add(new Thread(() => Consumer(producerConsumer)));
        //    threads.Add(new Thread(() => Consumer(producerConsumer)));

        //    foreach (var item in threads)
        //    {
        //        item.Start();
        //    }
        //}
        //private static void ProducerConsumerUsingLockAndMonitor()
        //{
        //    var producerConsumer = new ProducerConsumerUsingLockAndMonitor();
        //    var threads = new List<Thread>();
        //    threads.Add(new Thread(() => Producer(producerConsumer)));
        //    threads.Add(new Thread(() => Producer(producerConsumer)));
        //    threads.Add(new Thread(() => Consumer(producerConsumer)));
        //    threads.Add(new Thread(() => Consumer(producerConsumer)));

        //    foreach (var item in threads)
        //    {
        //        item.Start();
        //    }
        //}

        //static void Producer(IProducerConsumer producerConsumer)
        //{
        //    Random random = new Random();

        //    while (true)
        //    {
        //        int number = random.Next(100);
        //        producerConsumer.Produce(number);
        //        Console.WriteLine($"Produced: {number}");
        //        //Thread.Sleep(random.Next(500)); // Simulate some processing time
        //    }
        //}

        //static void Consumer(IProducerConsumer producerConsumer)
        //{
        //    while (true)
        //    {
        //        int number = producerConsumer.Consume();
        //        Console.WriteLine($"Consumed: {number}");
        //        //Thread.Sleep(250); // Simulate some processing time
        //    }
        //}     

        //private static void PrintBuffer(int[] buffer, int index)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("[");

        //    for (int i = 0; i <= index && i < buffer.Length; i++)
        //    {
        //        sb.Append($"{buffer[i]}, ");
        //    }

        //    sb.Append(']');

        //    Console.WriteLine(sb.ToString());
        //}
    }
}

