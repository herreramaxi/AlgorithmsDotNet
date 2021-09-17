using _4LinkedList;
using NUnit.Framework;

namespace _4LinkedLists.Tests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        [Test]
        public void TestInsertFirst()
        {
            var list = new DoublyLinkedList();
            list.InsertFirst(2);
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(2, list.Tail.Data);
            list.InsertFirst(1);
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(2, list.Tail.Data);

            Assert.AreEqual(new int[] { 1, 2 }, list.GetArray());
        }


        [Test]
        public void TestInsertLast()
        {
            var list = new DoublyLinkedList();
            list.InsertLast(2);
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(2, list.Tail.Data);
            list.InsertLast(1);
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(1, list.Tail.Data);

            Assert.AreEqual(new int[] { 2, 1 }, list.GetArray());
        }

        [Test]
        public void InsertAfter()
        {
            var list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            var middle = list.Tail;
            list.InsertLast(4);

            Assert.AreEqual(new int[] { 1, 2, 4 }, list.GetArray());

            list.InsertAfter(middle, 3);

            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, list.GetArray());
        }

        [Test]
        public void RemoveFirstAndLast()
        {
            var list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);

            list.RemoveFirst();
            Assert.AreEqual(new int[] { 2,3 }, list.GetArray());
            Assert.AreEqual(2,list.Head.Data);

            list.RemoveLast();
            Assert.AreEqual(new int[] { 2 }, list.GetArray());
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(2, list.Tail.Data);
        }

        [Test]
        public void Remove()
        {
            var list = new DoublyLinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            var middle = list.Tail;
            list.InsertLast(3);
            list.InsertLast(4);

            list.Remove(middle);
            Assert.AreEqual(new int[] { 1,3,4}, list.GetArray());
            list.Remove(list.Tail);
            Assert.AreEqual(new int[] { 1, 3 }, list.GetArray());
            Assert.AreEqual(3, list.Tail.Data);
        }
    }
}
