using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Sorting.Tests
{
    public class SelectionSortTests
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
        public void SelectionSortRecursive()
        {
           SelectionSort.Sort(_array);

            Assert.AreEqual(_sorted, _array);
        }

        [Test]
        public void SelectionSortNonrecursive()
        {
            SelectionSort.SortNonRecursive(_array);

            Assert.AreEqual(_sorted, _array);
        }
    }
}