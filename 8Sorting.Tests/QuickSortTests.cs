using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Sorting.Tests
{
    [TestFixture]
    public class QuickSortTests
    {
        private int[] _sorted;
        private int[] _originalArray;
        private int[] _array;

        [OneTimeSetUp]
        public void OneTimeSetup() {
            Random rnd = new Random();
            _sorted = Enumerable.Range(0, 30).ToArray();
            _originalArray = _sorted.OrderBy(_ => rnd.Next()).ToArray();            
        }

        [SetUp]
        public void Setup()
        {
            _array = new int[_originalArray.Length];
            Array.Copy(_originalArray, _array, _originalArray.Length);
        }

        [Test]
        public void QuickSortSimpleTest()
        {
            Assert.AreEqual(_sorted, QuickSort.QuickSortSimple(_array));
        }

        [Test]
        public void QuickSortLastElementTest()
        {
            Assert.AreEqual(_sorted, QuickSort.QuickSortLastElement(_array));
        }

        [Test]
        public void QuickSortMiddleElementTest()
        {
            Assert.AreEqual(_sorted, QuickSort.QuickSortMiddleElement(_array));
        }
    }
}
