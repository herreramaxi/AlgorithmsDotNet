using NUnit.Framework;

namespace _4LinkedLists.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestingSinleLinkedList()
        {
            var list = new SinlgyLinkedList();
            var first = list.InsertFirst(1);
            var second = list.InsertAfter(first, 2);
            list.InsertLast(4);
            var third = list.InsertAfter(second, 3);

            Assert.AreEqual(list.GetArray(), new int[] { 1, 2, 3, 4 });
            Assert.AreNotEqual(list.GetArray(), new int[] { 1, 2, 2, 4 });

            list.RemoveFirst();
            Assert.AreEqual(list.GetArray(), new int[] { 2, 3, 4 });
            Assert.AreNotEqual(list.GetArray(), new int[] { 1, 2, 3, 4 });

            list.Remove(third);
            Assert.AreEqual(list.GetArray(), new int[] { 2, 4 });
            Assert.AreNotEqual(list.GetArray(), new int[] { 2, 3, 4 });

            list.RemoveLast();
            Assert.AreEqual(list.GetArray(), new int[] { 2 });
            Assert.AreNotEqual(list.GetArray(), new int[] { 2, 4 });
        }

        [Test]
        public void TestingRemove()
        {
            var list = new SinlgyLinkedList();
            var first = list.InsertFirst(1);
            var second = list.InsertLast(2);
            var third = list.InsertLast(3);
            var last = list.InsertLast(4);

            Assert.IsTrue(list.Remove(first));
            Assert.IsTrue(list.Remove(third));
            Assert.AreEqual(list.GetArray(), new int[] { 2, 4 });
            Assert.IsTrue(list.Remove(last));

            Assert.AreEqual(list.GetArray(), new int[] { 2 });
            list.RemoveFirst();

            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestNth()
        {
            var list = new SinlgyLinkedList();
            list.InsertFirst(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.InsertLast(5);

            Assert.AreEqual(1, list.GetNthElement(0).Data);
            Assert.AreEqual(2, list.GetNthElement(1).Data);
            Assert.AreEqual(4, list.GetNthElement(3).Data);
            Assert.AreEqual(5, list.GetNthElement(4).Data);

            list = new SinlgyLinkedList();
            Assert.AreEqual(null, list.GetNthElement(0));
        }

        [Test]
        public void TestMthToLast()
        {
            var list = new SinlgyLinkedList();
            list.InsertFirst(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.InsertLast(5);

            Assert.AreEqual(5, list.GetMthToLast(0).Data);
            Assert.AreEqual(4, list.GetMthToLast(1).Data);
            Assert.AreEqual(3, list.GetMthToLast(2).Data);
            Assert.AreEqual(2, list.GetMthToLast(3).Data);
            Assert.AreEqual(1, list.GetMthToLast(4).Data);

            Assert.AreEqual(null, list.GetMthToLast(5));
        }

        [Test]
        public void TestAcyclic()
        {
            var acyclicList = new SinlgyLinkedList();
            acyclicList.InsertLast(3);
            acyclicList.InsertLast(2);
            var node4 =acyclicList.InsertLast(4);
           acyclicList.InsertLast(6);
            var node2=acyclicList.InsertLast(2);

            Assert.IsFalse(acyclicList.IsAcyclic());

            node2.Next = node4;

            Assert.IsTrue(acyclicList.IsAcyclic());
        }

        [Test]
        public void TestAcyclic2()
        {
            var acyclicList = new SinlgyLinkedList();
            acyclicList.InsertLast(3);
            acyclicList.InsertLast(2);
            var node4 = acyclicList.InsertLast(4);
            acyclicList.InsertLast(6);
            var node2 = acyclicList.InsertLast(2);

            Assert.IsFalse(acyclicList.IsAcyclic2());

            node2.Next = node4;

            Assert.IsTrue(acyclicList.IsAcyclic2());
        }

        [Test]
        public void TestAcyclic3()
        {
            var acyclicList = new SinlgyLinkedList();
            acyclicList.InsertLast(3);
            acyclicList.InsertLast(2);
            var node4 = acyclicList.InsertLast(4);
            acyclicList.InsertLast(6);
            var node2 = acyclicList.InsertLast(2);

            Assert.IsFalse(acyclicList.IsAcyclic3());

            node2.Next = node4;

            Assert.IsTrue(acyclicList.IsAcyclic3());
        }
    }
}