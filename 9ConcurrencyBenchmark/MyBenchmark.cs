using _9Concurency;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using NSubstitute;
using Serilog;

namespace _9ConcurrencyBenchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true), Config(typeof(Config))]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class MyBenchmark
    {
        [Params(1000)]
        public int MAX_VALUES;

        [Params(2)]
        public int MAX_PRODUCERS;
        [Params(2)]
        public int MAX_CONSUMERS;
        public MyBenchmark()
        {
            // Initialize your buffer here
            //buffer = new IntBufferNoProtected(8); // Example initialization
            //var producerConsumer  = new ProducerConsumerDirector(ProducerConsumerType.NoProtected, 1, 2,100);
            //var producerConsumer = new ProducerConsumerDirector(ProducerConsumerType.LockAndMonitor, 2, 2, 100);
            //var producerConsumer = new ProducerConsumerDirector(ProducerConsumerType.Dataflow, 4, 4, 10000);
        }

        [Benchmark(Baseline = true)]
        public void ProducerConsumer_LockAndMonitor()
        {
            var logger = Substitute.For<ILogger>();
            var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.LockAndMonitor, MAX_PRODUCERS, MAX_CONSUMERS, MAX_VALUES);
            producerConsumer.Run();
        }

        [Benchmark]
        public void ProducerConsumer_Dataflow()
        {
            var logger = Substitute.For<ILogger>();
            var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.Dataflow, MAX_PRODUCERS, MAX_CONSUMERS, MAX_VALUES);
            producerConsumer.Run();
        }

        [Benchmark]
        public void ProducerConsumer_Channel()
        {
            var logger = Substitute.For<ILogger>();
            var producerConsumer = new ProducerConsumerDirector(logger, ProducerConsumerType.Channel, MAX_PRODUCERS, MAX_CONSUMERS, MAX_VALUES);
            producerConsumer.Run();
        }

        private class Config : ManualConfig
        {
            public Config()
            {
                SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
            }
        }
    }


}
