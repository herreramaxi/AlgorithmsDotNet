namespace _9Concurency
{
    using System;
    using System.Text;
    using System.Threading;

    class Program
    {
        static int[] buffer = new int[8];
        static int index = 0;

        static void Main(string[] args)
        {
            Thread producerThread = new Thread(Producer);
            Thread consumerThread = new Thread(Consumer);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Program completed.");
        }

        static void Producer()
        {
            Random random = new Random();

            while (true)
            {
                int number = random.Next(100);
                Produce(number);
                Console.WriteLine($"Produced: {number}");
                Thread.Sleep(random.Next(500)); // Simulate some processing time
            }
        }

        static void Consumer()
        {
            while (true)
            {
                int number = Consume();
                Console.WriteLine($"Consumed: {number}");
                Thread.Sleep(250); // Simulate some processing time
            }
        }

        static void Produce(int number)
        {
            lock (buffer)
            {
                while (index == buffer.Length)
                {
                    Monitor.Wait(buffer);
                }

                buffer[index++] = number;

                PrintBuffer(buffer, index);

                Monitor.Pulse(buffer);
            }
        }       

        static int Consume()
        {
            lock (buffer)
            {
                while (index == 0)
                {
                    Monitor.Wait(buffer);
                }

                int number = buffer[--index];
                PrintBuffer(buffer, index);

                Monitor.Pulse(buffer);
                return number;
            }
        }

        private static void PrintBuffer(int[] buffer, int index)
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
