using System.Text;
using System;

namespace _9Concurency
{
    public class IntBufferNoProtected : IBufferAddRemove
    {
        private int index;
        private readonly int[] buffer;

        public IntBufferNoProtected(int maxSize)
        {
            buffer = new int[maxSize];
        }

        public void Add(int number)
        {
            //busy waiting
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

        public int Remove()
        { 
            //busy waiting
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
