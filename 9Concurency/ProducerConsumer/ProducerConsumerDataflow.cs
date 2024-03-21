using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace _9Concurency
{
    public class ProducerConsumerDataflow : IProducerConsumer
    {
        private readonly ILogger logger;
        protected readonly BufferBlock<int> _buffer;
        private readonly bool _simulateProcessingTime;

        public ProducerConsumerDataflow(ILogger logger, BufferBlock<int> buffer, bool simulateProcessingTime)
        {
            this.logger = logger;
            _buffer = buffer;
            this._simulateProcessingTime = simulateProcessingTime;
        }

        public void Producer(int maxValuesToBeGenerated)
        {
            Random random = new Random();

            while (maxValuesToBeGenerated > 0)
            {
                int number = random.Next(100);
                _buffer.Post(number);
                logger.Information($"Produced ({maxValuesToBeGenerated}): {number}");

                if (_simulateProcessingTime)
                    Thread.Sleep(random.Next(500)); // Simulate some processing time

                maxValuesToBeGenerated--;
            }

            //_buffer.Complete();
        }

        public void Consumer(int maxValuesToBeGenerated)
        {
            while (maxValuesToBeGenerated > 0)  // && await _buffer.OutputAvailableAsync()
            {
                int number = _buffer.Receive();
                logger.Information($"Consumed ({maxValuesToBeGenerated}): {number}");

                if (_simulateProcessingTime)
                    Thread.Sleep(250); // Simulate some processing time

                maxValuesToBeGenerated--;
            }
        }
    }
}
