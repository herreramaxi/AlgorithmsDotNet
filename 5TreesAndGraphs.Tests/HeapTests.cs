using NUnit.Framework;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
   public class HeapTests
    {
        [Test]
        public void MinHeapTest() {
            var heap = new MinHeap();
            heap.Add(3);
            heap.Add(10);
            heap.Add(15);
            heap.Add(25);
            heap.Add(30);
            heap.Add(5);
            heap.Add(22);
            heap.Add(20);

           Assert.AreEqual( new int[] { 3,10,5,20,30,15,22,25},heap.GetArray());
        }

        [Test]
        public void MaxHeapTest()
        {
            var heap = new MaxHeap();
            heap.Add(3);
            heap.Add(10);
            heap.Add(15);
            heap.Add(25);
            heap.Add(30);
            heap.Add(5);
            heap.Add(22);
            heap.Add(20);

            Assert.AreEqual(new int[] { 30,25,22,20,15,5,10,3 }, heap.GetArray());
        }
    }
}
