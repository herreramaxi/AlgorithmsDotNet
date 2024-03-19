using _9Concurency;
using BenchmarkDotNet.Running;
using NSubstitute;
using Serilog;
using System;

namespace _9ConcurrencyBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var logger = Substitute.For<ILogger>();
            //var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.LockAndMonitor, 2, 2, 1000);
            //producerConsumer.Run();
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }
}
