using Serilog;
using System;
using System.Threading;
using System.Threading.Channels;

namespace _9Concurency
{
    public class ProducerConsumerChannel : IProducerConsumer
    {
        private readonly Channel<int> _channel;
        private readonly ILogger logger;
        private readonly bool _simulateProcessingTime;
        public ProducerConsumerChannel(ILogger logger, Channel<int> buffer, bool simulateProcessingTime)
        {
            this.logger = logger;
            _channel = buffer;
            this._simulateProcessingTime = simulateProcessingTime;
        }

        public async void Producer(int maxValuesToBeGenerated)
        {
            Random random = new Random();

            while (maxValuesToBeGenerated > 0)
            {
                int number = random.Next(100);
                await _channel.Writer.WriteAsync(number);
                logger.Information($"Produced ({maxValuesToBeGenerated}): {number}");

                if (_simulateProcessingTime)
                    Thread.Sleep(random.Next(500)); // Simulate some processing time

                maxValuesToBeGenerated--;
            }
        }

        public async void Consumer(int maxValuesToBeGenerated)
        {
            while (await _channel.Reader.WaitToReadAsync())
            {
                while (maxValuesToBeGenerated > 0 && _channel.Reader.TryRead(out var number))
                {
                    logger.Information($"Consumed ({maxValuesToBeGenerated}): {number}");

                    if (_simulateProcessingTime)
                        Thread.Sleep(250); // Simulate some processing time

                    maxValuesToBeGenerated--;
                }
            }
        }


    }
}
