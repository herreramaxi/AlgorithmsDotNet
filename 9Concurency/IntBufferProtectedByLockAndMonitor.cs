using System.Threading;

namespace _9Concurency
{
    public interface IBufferAddRemove {
        void Add(int number);
        int Remove();
    }
    public class IntBufferProtectedByLockAndMonitor: IBufferAddRemove
    {
        private int index;
        private readonly int[] buffer;

        public IntBufferProtectedByLockAndMonitor(int maxSize)
        {
            buffer = new int[maxSize];
        }

        public void Add(int number)
        {
            lock (buffer)
            {
                while (index == buffer.Length)
                {
                    Monitor.Wait(buffer);
                }

                buffer[index++] = number;
                //PrintBuffer();
                Monitor.PulseAll(buffer);
            }
        }

        public int Remove()
        {
            lock (buffer)
            {
                while (index == 0)
                {
                    Monitor.Wait(buffer);
                }

                var number = buffer[--index];
                //PrintBuffer();
                Monitor.PulseAll(buffer);

                return number;
            }
        }

    }
}
