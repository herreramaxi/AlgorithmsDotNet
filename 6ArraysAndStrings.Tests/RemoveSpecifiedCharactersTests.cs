using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6ArraysAndStrings.Tests
{
    [TestFixture]
   public  class RemoveSpecifiedCharactersTests
    {
        private string _longString;

        [SetUp]
        public void Setup()
        {
            _longString = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum";
        }

        [Test]
        public void TestRemoveSpecifiedCharacters()
        {
            Assert.AreEqual("Hll Wrld", RemoveSpecifiedCharacters.RemoveChars("Hello World!!!", "eo!"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveChars("Hello World!!!", "z"));
            Assert.AreEqual("", RemoveSpecifiedCharacters.RemoveChars("Hello World!!!", "eo!Hl Wrd"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveChars("Hello World!!!", ""));
            Assert.AreEqual(_longString, RemoveSpecifiedCharacters.RemoveChars(_longString, ""));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!\n", "\n"));
        }

        [Test]
        public void TestRemoveSpecifiedCharactersWithHashSet()
        {
            Assert.AreEqual("Hll Wrld", RemoveSpecifiedCharacters.RemoveCharsWithHash("Hello World!!!", "eo!"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithHash("Hello World!!!", "z"));
            Assert.AreEqual("", RemoveSpecifiedCharacters.RemoveCharsWithHash("Hello World!!!", "eo!Hl Wrd"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithHash("Hello World!!!", ""));
            Assert.AreEqual(_longString, RemoveSpecifiedCharacters.RemoveCharsWithHash(_longString, ""));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!\n", "\n"));
        }

        [Test]
        public void TestRemoveSpecifiedCharactersWithArrays()
        {
            Assert.AreEqual("Hll Wrld", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!", "eo!"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!", "z"));
            Assert.AreEqual("", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!", "eo!Hl Wrd"));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!", ""));
            Assert.AreEqual(_longString, RemoveSpecifiedCharacters.RemoveCharsWithArrays(_longString, ""));
            Assert.AreEqual("Hello World!!!", RemoveSpecifiedCharacters.RemoveCharsWithArrays("Hello World!!!\n", "\n"));
        }
    }
}
