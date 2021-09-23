using NUnit.Framework;
using System;
using System.Linq;

namespace _8Sorting.Tests
{
    [TestFixture]
    public class InsertionSortTests
    {
        private int[] _sorted;
        private int[] _array;

        [SetUp]
        public void Setup()
        {
            Random rnd = new Random();
            _sorted = Enumerable.Range(0, 20).ToArray();
           _array = _sorted.OrderBy(_ => rnd.Next()).ToArray();
            
        }

        [Test]
        public void InsertionSortSimpleTest()
        {
           InsertionSort.SortSimple(_array);

            Assert.AreEqual(_sorted, _array);
        }

        [Test]
        public void InsertionSortTest()
        {
            InsertionSort.Sort(_array);

            Assert.AreEqual(_sorted, _array);
        }
    }
}