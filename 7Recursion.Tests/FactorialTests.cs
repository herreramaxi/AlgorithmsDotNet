using NUnit.Framework;

namespace _7Recursion.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FactorialRecursiveTests()
        {
            Assert.AreEqual(1, FactorialR.Factorial(0));
            Assert.AreEqual(1, FactorialR.Factorial(1));
            Assert.AreEqual(2, FactorialR.Factorial(2));
            Assert.AreEqual(6, FactorialR.Factorial(3));
            Assert.AreEqual(24, FactorialR.Factorial(4));
            Assert.AreEqual(3628800, FactorialR.Factorial(10));

        }

        [Test]
        public void FactorialNonRecursiveTests()
        {
            Assert.AreEqual(1, FactorialR.FactorialNonRecursive(0));
            Assert.AreEqual(1, FactorialR.FactorialNonRecursive(1));
            Assert.AreEqual(2, FactorialR.FactorialNonRecursive(2));
            Assert.AreEqual(6, FactorialR.FactorialNonRecursive(3));
            Assert.AreEqual(24, FactorialR.FactorialNonRecursive(4));
            Assert.AreEqual(3628800, FactorialR.FactorialNonRecursive(10));
        }

        [Test]
        public void AllFactorialsTests()
        {
            Assert.AreEqual(new int[] { 1 }, FactorialR.AllFactorials(0));
            Assert.AreEqual(new int[] { 1 }, FactorialR.AllFactorials(1));
            Assert.AreEqual(new int[] { 2, 1 }, FactorialR.AllFactorials(2));
            Assert.AreEqual(new int[] { 6, 2, 1 }, FactorialR.AllFactorials(3));
            Assert.AreEqual(new int[] { 24, 6, 2, 1 }, FactorialR.AllFactorials(4));
            Assert.AreEqual(3628800, FactorialR.AllFactorials(10)[0]);
        }
    }
}