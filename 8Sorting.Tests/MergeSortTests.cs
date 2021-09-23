using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Sorting.Tests
{
    [TestFixture]
    class MergeSortTests
    {
        private int[] _sorted;
        private int[] _originalArray;
        private int[] _array;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Random rnd = new Random();
            _sorted = Enumerable.Range(1, 5).ToArray();
            _originalArray = _sorted.OrderBy(_ => rnd.Next()).ToArray();
        }

        [SetUp]
        public void Setup()
        {
            _array = new int[_originalArray.Length];
            Array.Copy(_originalArray, _array, _originalArray.Length);
        }

        [Test]
        public void MergeSortSimpleTest()
        {
            Assert.AreEqual(_sorted, MergeSort.MergeSortSimple(_array));
        }

        [Test]
        public void MergeSort2Test()
        {
            Assert.AreEqual(_sorted, MergeSort.MergeSort2(_array));
        }
    }
}
