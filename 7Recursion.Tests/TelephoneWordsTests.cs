using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _7Recursion.Tests
{
    [TestFixture]
    public class TelephoneWordsTests
    {
        [Test]
        public void Test() {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var t = new TelephoneWords(new int[] { 4, 9, 7, 1, 9, 2, 7 });
            t.PrintWords();

            var output = sw.ToString();
        }
    }
}
