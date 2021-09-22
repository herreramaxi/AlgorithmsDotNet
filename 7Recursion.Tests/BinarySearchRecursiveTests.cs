using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7Recursion.Tests
{
    [TestFixture]
    public class BinarySearchRecursiveTests
    {
        [Test]
        public void Test()
        {
            var array = Enumerable.Range(0, 11).ToArray();

            Assert.AreEqual(0, BinarySearchRecursive.BS(array, 0));
            Assert.AreEqual(10, BinarySearchRecursive.BS(array, 10));
            Assert.AreEqual(5, BinarySearchRecursive.BS(array, 5));
            Assert.AreEqual(3, BinarySearchRecursive.BS(array, 3));
            Assert.AreEqual(9, BinarySearchRecursive.BS(array, 9));
            Assert.AreEqual(-1, BinarySearchRecursive.BS(array, -10));
        }
    }
}
