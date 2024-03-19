using System.Threading.Tasks.Dataflow;

namespace _9Concurency
{
    public class IntBufferDataflow : IBufferAddRemove
    {
        private readonly BufferBlock<int> _buffer = new BufferBlock<int>();

        public void Add(int number)
        {
            _buffer.Post(number);
        }

        public int Remove()
        {
            return _buffer.Receive();
        }

        public bool OutputAvailable() {
            return _buffer.OutputAvailableAsync().Result;
        }
    }
}
