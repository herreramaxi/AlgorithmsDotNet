using System;

namespace _9Concurency
{
    public interface IProducerConsumer
    {
        void Producer(int maxValuesToBeGenerated);
        void Consumer(int maxValuesToBeGenerated);
    }
    public abstract class ProducerConsumerBase//: IProducerConsumer
    {
        private readonly int _maxValuesToBeGenerated;

        public ProducerConsumerBase(int maxValuesToBeGenerated = 100)
        {
            this._maxValuesToBeGenerated = maxValuesToBeGenerated;
        }
        public void Producer()
        {
            Random random = new Random();

            for (int i = _maxValuesToBeGenerated; i > 0; i--)
            {
                int number = random.Next(100);
                this.Produce(number);
                Console.WriteLine($"Produced: {number}");
                //Thread.Sleep(random.Next(500)); // Simulate some processing time
            }
        }

        public void Consumer()
        {
            for (int i = _maxValuesToBeGenerated; i > 0; i--)
            {
                int number = this.Consume();
                Console.WriteLine($"Consumed: {number}");
                //Thread.Sleep(250); // Simulate some processing time
            }
        }

        protected abstract void Produce(int number);
        protected abstract int Consume();
    }
}
