using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace _7Recursion.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void Test()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var permutations = new Permutations("abc");
            permutations.Permute();
        }

        [Test]
        public void Test2()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            Permutations.Permute2("abc");
            var outpout = sw.ToString();
        }

        [Test]
        public void Test3()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            Permutations.Permute3("abc");
            var outpout = sw.ToString();
        }


        [Test]
        public void Test4()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var permutations = new Permutations("abca");
            permutations.Permute();
            Console.WriteLine();
            Permutations.Permute2("abca");
            Console.WriteLine();
            Permutations.Permute3("abca");
            var outpout = sw.ToString();
        }

        [Test]
        public void Test5()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var permutations = new Permutations("AABC");
            permutations.Permute();

            var output = sw.ToString();
            var sorted = output.Split('\n').ToList().OrderBy(x => x);
        }

    }
}
