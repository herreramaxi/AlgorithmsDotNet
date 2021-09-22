using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7Recursion.Tests
{
    [TestFixture]
    public class CombinationsTests
    {
        [Test]
        public void Test() {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var com = new Combinations("wxyz");
            com.Combine();
            var output = sw.ToString();
        }

        [Test]
        public void Test2()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var com = new Combinations("abc");
            com.Combine();
            var output = sw.ToString();

        }

        [Test]
        public void Test3()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var com = new Combinations("AABC");
            com.Combine();
            var output = sw.ToString();
            var sorted = output.Split('\n').ToList().OrderBy(x => x);
        }
    }
}
