using Serilog;
using System;
using System.Threading;

namespace _9Concurency
{
    public class ProducerConsumer : IProducerConsumer
    {
        private readonly ILogger logger;
        private readonly IBufferAddRemove _buffer;
        private readonly bool _simulateProcessingTime;

        public ProducerConsumer(ILogger logger, IBufferAddRemove buffer, bool simulateProcessingTime = false)
        {
            this.logger = logger;
            this._buffer = buffer;
            this._simulateProcessingTime = simulateProcessingTime;
        }

        public virtual void Producer(int maxValuesToBeGenerated)
        {
            Random random = new Random();

            while (maxValuesToBeGenerated > 0)
            {
                int number = random.Next(100);
                _buffer.Add(number);
                logger.Information($"Produced ({maxValuesToBeGenerated}): {number}");

                if (_simulateProcessingTime)
                    Thread.Sleep(random.Next(500)); // Simulate some processing time

                maxValuesToBeGenerated--;
            }
        }

        public virtual void Consumer(int maxValuesToBeGenerated)
        {
            while (maxValuesToBeGenerated > 0)
            {
                int number = _buffer.Remove();
                logger.Information($"Consumed ({maxValuesToBeGenerated}): {number}");

                if (_simulateProcessingTime)
                    Thread.Sleep(250); // Simulate some processing time

                maxValuesToBeGenerated--;
            }
        }
    }
}

