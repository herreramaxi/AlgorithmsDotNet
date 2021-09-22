using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6ArraysAndStrings.Tests
{
    [TestFixture]
   public class StringToIntTests
    {
        [Test]
        public void Test() {
            Assert.AreEqual(123456789,StringToInt.Get("123456789"));
            Assert.AreEqual(0, StringToInt.Get(null));
            Assert.AreEqual(2147483647, StringToInt.Get("2147483647"));
            Assert.AreEqual(-2147483648, StringToInt.Get("-2147483648"));
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(123456789, StringToInt.Get1("123456789"));
            Assert.AreEqual(0, StringToInt.Get1(null));
            Assert.AreEqual(2147483647, StringToInt.Get1("2147483647"));
            Assert.AreEqual(-2147483648, StringToInt.Get1("-2147483648"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(123456789, StringToInt.Get2("123456789"));
            Assert.AreEqual(0, StringToInt.Get2(null));
            Assert.AreEqual(2147483647, StringToInt.Get2("2147483647"));
            Assert.AreEqual(-2147483648, StringToInt.Get2("-2147483648"));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(123456789, StringToInt.Get3("123456789"));
            Assert.AreEqual(0, StringToInt.Get3(null));
            Assert.AreEqual(2147483647, StringToInt.Get3("2147483647"));
            Assert.AreEqual(-2147483648, StringToInt.Get3("-2147483648"));
        }
    }
}
