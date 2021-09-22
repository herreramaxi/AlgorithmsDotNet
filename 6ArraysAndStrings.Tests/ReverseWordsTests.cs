using NUnit.Framework;

namespace _6ArraysAndStrings.Tests
{
    [TestFixture]
    public
    class ReverseWordsTests
    {

        [Test]
        public void Test1() {
            Assert.AreEqual("try. no is there not, do or Do",ReverseWords.Get("Do or do not, there is no try."));
            Assert.AreEqual("", ReverseWords.Get(""));
            Assert.AreEqual(null, ReverseWords.Get(null));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("try. no is there not, do or Do", ReverseWords.Get2("Do or do not, there is no try."));
            Assert.AreEqual("", ReverseWords.Get2(""));
            Assert.AreEqual(null, ReverseWords.Get2(null));
        }


        [Test]
        public void Test3()
        {
            Assert.AreEqual("try. no is there not, do or Do", ReverseWords.Get3("Do or do not, there is no try."));
            Assert.AreEqual("", ReverseWords.Get3(""));
            Assert.AreEqual(null, ReverseWords.Get3(null));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual("try. no is there not, do or Do", ReverseWords.Get4("Do or do not, there is no try."));
            Assert.AreEqual("", ReverseWords.Get4(""));
            Assert.AreEqual(null, ReverseWords.Get4(null));
        }
    }
}
