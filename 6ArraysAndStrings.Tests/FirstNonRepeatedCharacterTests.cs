using NUnit.Framework;

namespace _6ArraysAndStrings.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestFirstNonRepeatedCharacter()
        {
            Assert.AreEqual('r', FirstNonRepeatedCharacter.Get("teeter"));
            Assert.AreEqual(null, FirstNonRepeatedCharacter.Get("teeterr"));
            Assert.AreEqual('\n', FirstNonRepeatedCharacter.Get("teeterr\n"));
        }

    }
}