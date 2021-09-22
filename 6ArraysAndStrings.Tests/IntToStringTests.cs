using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6ArraysAndStrings.Tests
{
    [TestFixture]
    public class IntToStringTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual("0", IntToString.Get(0));
            Assert.AreEqual("1", IntToString.Get(1));
            Assert.AreEqual("1234567", IntToString.Get(1234567));
            Assert.AreEqual(int.MaxValue.ToString(), IntToString.Get(int.MaxValue));
            Assert.AreEqual(int.MinValue.ToString(), IntToString.Get(int.MinValue));
        }
    }
}
