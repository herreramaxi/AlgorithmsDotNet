using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace _9Concurency
{
    public interface IProducerConsumerAsync: IProducerConsumer
    {
        Task<int> ConsumeAsync();
    }
    public class ProducerConsumerDataflow2 : ProducerConsumerBase//IProducerConsumerAsync
    {
        private readonly BufferBlock<int> _buffer;

        public ProducerConsumerDataflow2(int maxToBeGenerated): base(maxToBeGenerated)
        {
            _buffer = new BufferBlock<int>();
        }

        protected override void Produce(int number)
        {
            _buffer.Post(number);
        }

        public async Task<int> ConsumeAsync()
        {
            var count = 0;
            while (await _buffer.OutputAvailableAsync())
            {
                var data = await _buffer.ReceiveAsync();
                count++;
            }

            return count;
        }

        protected override int Consume()
        {
            return this.ConsumeAsync().Result;
        }
    }
}
