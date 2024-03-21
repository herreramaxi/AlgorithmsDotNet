using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace _9Concurency
{
    //public interface IProducerConsumer
    //{
    //    void Produce(int number);
    //    int Consume();
    //}
    public class ProducerConsumerUsingLockAndMonitor : ProducerConsumerBase
    {
        private static int index;
        private readonly int[] buffer;
        private readonly int sharedIndex;

        public ProducerConsumerUsingLockAndMonitor(int[] buffer, ref int sharedIndex, object bufferLock, int maxValuesToBeGenerated = 100) : base(maxValuesToBeGenerated)
        {
            this.buffer = buffer;
            this.sharedIndex = sharedIndex;
        }

        protected override void Produce(int number)
        {
            lock (buffer)
            {
                while (index == buffer.Length - 1)
                {
                    Monitor.Wait(buffer);
                }

                buffer[index++] = number;
                //PrintBuffer();
                Monitor.Pulse(buffer);
            }
        }

        protected override int Consume()
        {
            lock (buffer)
            {
                while (index == 0)
                {
                    Monitor.Wait(buffer);
                }

                var number = buffer[--index];
                //PrintBuffer();
                Monitor.Pulse(buffer);

                return number;
            }
        }
        public void PrintBuffer()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i <= index && i < buffer.Length; i++)
            {
                sb.Append($"{buffer[i]}, ");
            }

            sb.Append(']');

            Console.WriteLine(sb.ToString());
        }

    }
}
