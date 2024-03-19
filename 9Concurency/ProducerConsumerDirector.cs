using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

namespace _9Concurency
{
    public enum ProducerConsumerType
    {
        NoProtected = 0,
        LockAndMonitor = 1,
        Dataflow = 2,
        Channel = 3,
    }
    public class ProducerConsumerDirector
    {
        private readonly ILogger _logger;
        private readonly int _maxValuesToBeGenerated;
        private readonly IList<Thread> _producers = new List<Thread>();
        private readonly IList<Thread> _consumers = new List<Thread>();
        public ProducerConsumerDirector(ILogger logger ,ProducerConsumerType type, int producersQuantity = 1, int consumersQuantity = 1, int maxValuesToBeGeneratedByProducer = 100, bool simulateProcessingTime = false)
        {
            _logger = logger;
            _maxValuesToBeGenerated = maxValuesToBeGeneratedByProducer;
            var intBufferNoProtected = new IntBufferNoProtected(8);
            var intBufferProtectedByLockAndMonitor = new IntBufferProtectedByLockAndMonitor(8);
            var intBufferDataflow = new BufferBlock<int>();
            var intBufferChannel = Channel.CreateUnbounded<int>();

            var buffersByType = new Dictionary<ProducerConsumerType, object>() {
                { ProducerConsumerType.NoProtected, intBufferNoProtected },
                { ProducerConsumerType.LockAndMonitor, intBufferProtectedByLockAndMonitor},
                { ProducerConsumerType.Dataflow, intBufferDataflow},
                { ProducerConsumerType.Channel, intBufferChannel}
            };

            var producerConsumer = GetProducerConsumer(logger, type, buffersByType, simulateProcessingTime);
                    
            for (int i = 0; i < producersQuantity; i++)
            {
                var maxValues = _maxValuesToBeGenerated / producersQuantity;

                if (i == 0 && producersQuantity > 1 && _maxValuesToBeGenerated % producersQuantity > 0)
                {
                    maxValues += _maxValuesToBeGenerated % producersQuantity;
                }

                _producers.Add(new Thread(() => producerConsumer.Producer(maxValues)));
            }

            for (int i = 0; i < consumersQuantity; i++)
            {
                var maxValues = _maxValuesToBeGenerated / consumersQuantity;

                if (i == 0 && consumersQuantity > 1 && _maxValuesToBeGenerated % consumersQuantity > 0)
                {
                    maxValues += _maxValuesToBeGenerated % consumersQuantity;
                }

                _consumers.Add(new Thread(() => producerConsumer.Consumer(maxValues)));
            }
        }

        public void Run()
        {
            //Program.Log($"Starting Producers/consumers");

            foreach (var item in _consumers)
            {
                item.Start();
            }

            foreach (var item in _producers)
            {
                item.Start();
            }

            // Wait for all producers to complete
            foreach (var producerThread in _producers)
            {
                producerThread.Join();
            }

            // Wait for all consumers to complete
            foreach (var consumerThread in _consumers)
            {
                consumerThread.Join();
            }

            _logger.Information($"All elements produced and consumed: {_maxValuesToBeGenerated}");            
        }

        private IProducerConsumer GetProducerConsumer(ILogger logger, ProducerConsumerType type, Dictionary<ProducerConsumerType, object> buffersByType, bool simulateProcessingTime)
        {
            var buffer = buffersByType[type];

            switch (type)
            {
                case ProducerConsumerType.NoProtected: return new ProducerConsumer(logger, (IBufferAddRemove)buffer, simulateProcessingTime);
                case ProducerConsumerType.LockAndMonitor: return new ProducerConsumer(logger, (IBufferAddRemove)buffer, simulateProcessingTime);
                case ProducerConsumerType.Dataflow: return new ProducerConsumerDataflow(logger, (BufferBlock<int>)buffer, simulateProcessingTime);
                case ProducerConsumerType.Channel: return new ProducerConsumerChannel(logger, (Channel<int>)buffer, simulateProcessingTime);
                default: throw new NotImplementedException();
            }
        }
    }
}
