
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace _4LinkedLists.Tests
{

    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestingSinleLinkedList()
        {
            var stack = new StackAsSinglyLinkedList();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Assert.AreEqual(4, stack.Count());
            Assert.AreEqual(4, stack.Peek());

            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(3, stack.Peek());

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Peek());

            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Peek());

            Assert.AreEqual(1, stack.Pop());
        }
    }
}
