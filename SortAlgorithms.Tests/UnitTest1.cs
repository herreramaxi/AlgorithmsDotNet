using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithms.Tests
{
    [TestFixture]
    public class Tests
    {
        private int[] array;
        private IEnumerable<int> sorted;

        [SetUp]
        public void Setup()
        {
            Random rnd = new Random();
            sorted = Enumerable.Range(1, 50);
            array = sorted.OrderBy(_ => rnd.Next()).ToArray<int>();         
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
            BubbleSort.Sort(array);
            Assert.AreEqual(sorted, array);
        }

        [Test]
        public void TestInsertSort()
        {
            InsertionSort.Sort(array);
            Assert.AreEqual(sorted, array);
        }

        [Test]
        public void TestMergeSort()
        {           
            MergeSort.Sort(array);
            Assert.AreEqual(sorted, array);
        }

        [Test]
        public void TestQuickSortMiddleElementPivot()
        {         
            QuickSort.QuickSortMiddleElementPivot(array);
            Assert.AreEqual(sorted, array);
        }

        [Test]
        public void TestQuickSortLastElementPivot()
        {
            QuickSort.QuickSortLastElementPivot(array,0 ,array.Length-1); 
            Assert.AreEqual(sorted, array);
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