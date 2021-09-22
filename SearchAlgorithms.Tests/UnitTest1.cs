using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithms.Tests
{
    public class Tests
    {
        private int[] _array;

        [SetUp]
        public void Setup()
        {
            _array = Enumerable.Range(1, 50).ToArray();
        }

        [Test]
        public void TestLinearSearch()
        {
            Assert.IsTrue(SearchAlgorithms.LinearSearch(_array, 51) < 0);
            Assert.IsTrue(SearchAlgorithms.LinearSearch(_array, 25) >= 0);
            Assert.AreEqual(SearchAlgorithms.LinearSearch(_array, 25), 24);
            Assert.IsTrue(SearchAlgorithms.LinearSearch(_array, 10) >= 0);
            Assert.AreEqual(SearchAlgorithms.LinearSearch(_array, 10), 9);
            Assert.IsTrue(SearchAlgorithms.LinearSearch(_array, 45) >= 0);
            Assert.AreEqual(SearchAlgorithms.LinearSearch(_array, 45), 44);
            //var longArray =Enumerable.Range(1, int.MaxValue/2).ToArray();
            //Assert.IsTrue(SearchAlgorithms.LinearSearch(longArray, (int.MaxValue / 2) + 1) <0);
        }

        [Test]
        public void TestBinarySearch()
        {
            Assert.IsTrue(SearchAlgorithms.BinarySearch(_array, 51) < 0);
            Assert.IsTrue(SearchAlgorithms.BinarySearch(_array, 25) >= 0);
            Assert.AreEqual(SearchAlgorithms.BinarySearch(_array, 25),24);
            Assert.IsTrue(SearchAlgorithms.BinarySearch(_array, 10) >= 0); 
            Assert.AreEqual(SearchAlgorithms.BinarySearch(_array, 10), 9);
            Assert.IsTrue(SearchAlgorithms.BinarySearch(_array, 45) >= 0);
            Assert.AreEqual(SearchAlgorithms.BinarySearch(_array, 45), 44);
            //var longArray = Enumerable.Range(1, int.MaxValue/2).ToArray();
            //Assert.IsTrue(SearchAlgorithms.BinarySearch(longArray, (int.MaxValue / 2) +1) < 0);
        }
    }
}