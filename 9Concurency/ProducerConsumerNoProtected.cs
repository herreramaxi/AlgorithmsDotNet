using System;
using System.Text;

namespace _9Concurency
{
    public class ProducerConsumerNoProtected : ProducerConsumerBase
    {
        private static int index;
        private static int[] buffer = new int[8];

        public ProducerConsumerNoProtected(int maxToBeGenerated) : base(maxToBeGenerated)
        {
        }

        protected override void Produce(int number)
        {
            while (true)
            {
                if (index < buffer.Length)
                {
                    buffer[index++] = number;
                    //PrintBuffer();
                    return;
                }
            }
        }

        protected override int Consume()
        {
            while (true)
            {
                if (index > 0)
                {
                    var number = buffer[--index];
                    //PrintBuffer();
                    return number;
                }
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
