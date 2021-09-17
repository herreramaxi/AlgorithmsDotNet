using NUnit.Framework;
using System;
using System.Linq;

namespace SortAlgorithms.Tests
{
    [TestFixture]
    public class Tests
    {
        private int[] array;

        [SetUp]
        public void Setup()
        {
            Random rnd = new Random();
            array = Enumerable.Range(1, 50).OrderBy(_ => rnd.Next()).ToArray<int>();
        }

        [Test]
        public void TestIsSortedAsc() {
            var sortedArray = Enumerable.Range(1, 50).ToArray();
            Assert.IsTrue(IsSortedAsc(sortedArray));

            var noSOrtedArray = new int[] { 10, 11, 12, 13, 14, 20, 1, 2, 3 };
            Assert.IsFalse(IsSortedAsc(noSOrtedArray));
        }

        [Test]
        public void TestBubbleSort()
        {
            Assert.IsFalse(this.IsSortedAsc(array));
            BubbleSort.Sort(array);
            Assert.IsTrue(this.IsSortedAsc(array));
        }

        [Test]
        public void TestInsertSort()
        {
            Assert.IsFalse(this.IsSortedAsc(array));
            InsertionSort.Sort(array);
            Assert.IsTrue(this.IsSortedAsc(array));
        }

        [Test]
        public void TestMergeSort()
        {
            Assert.IsFalse(this.IsSortedAsc(array));
            MergeSort.Sort(array);
            Assert.IsTrue(this.IsSortedAsc(array));
        }

        [Test]
        public void TestQuickSort()
        {
            Assert.IsFalse(this.IsSortedAsc(array));
            QuickSort.Sort(array);
            Assert.IsTrue(this.IsSortedAsc(array));
        }


        private bool? IsSortedAsc(int[] array)
        {
            for (int i = 0; i < array.Length-2; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }

            return true;
        }
    }
}