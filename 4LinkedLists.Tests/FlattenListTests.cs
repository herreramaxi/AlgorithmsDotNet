using NUnit.Framework;

namespace _4LinkedList
{
    [TestFixture]
    public class FlattenListTests
    {
        private DoublyLinkedList _list;

        [SetUp]
        public void Setup() {
             _list = new DoublyLinkedList();
            _list.InsertLast(5);

            var node5 = _list.Head;
            var node6_1 = node5.InsertChild(6);
            var node25 = node6_1.InsertLast(25);
            node25.InsertChild(8);
            var node6 = node25.InsertLast(6);
            node6.InsertChild(9).InsertChild(7);

            _list.InsertLast(33);
            _list.InsertLast(17);
            _list.InsertLast(2);
            var node2 = _list.Tail;

            var firstLevelNode2 = node2.InsertChild(2);
            firstLevelNode2.InsertLast(7);
            var secondLevelN12 = firstLevelNode2.InsertChild(12);
            secondLevelN12.InsertLast(5);
            secondLevelN12.InsertChild(21).InsertLast(3);

            _list.InsertLast(1);
        
        }
        [Test]
        public void TestFlattern()
        {
            _list.FlattenList();
            var array = _list.GetArray();
            Assert.AreEqual(new int[] { 5, 33, 17, 2, 1, 6, 25, 6, 2, 7, 8, 9, 12, 5, 7, 21, 3 }, array);
        }

        [Test]
        public void TestUnFlattening()
        {
            _list.FlattenList();
            var array = _list.GetArray();
            Assert.AreEqual(new int[] { 5, 33, 17, 2, 1, 6, 25, 6, 2, 7, 8, 9, 12, 5, 7, 21, 3 }, array);

            _list.Unflattening();
             array = _list.GetArray();
            Assert.AreEqual(new int[] { 5, 33, 17, 2, 1, }, array);
        }


        [Test]
        public void TestFlattern2()
        {
            _list.FlattenList2();
            var array = _list.GetArray();
            Assert.AreEqual(new int[] { 5, 6, 25, 8, 6, 9, 7, 33, 17, 2, 2, 12, 21, 3, 5, 7, 1 }, array);
        }

        [Test]
        public void TestFlattern3()
        {          
            _list.FlattenList3();
            var array = _list.GetArray();
            Assert.AreEqual(new int[] { 5, 6, 25, 8, 6, 9, 7, 33, 17, 2, 2, 12, 21, 3, 5, 7, 1 }, array);
        }

        //[Test]
        //public void TestUnFlattening3()
        //{
        //    _list.FlattenList3();
        //    var array = _list.GetArray();
        //    Assert.AreEqual(new int[] { 5, 6, 25, 8, 6, 9, 7, 33, 17, 2, 2, 12, 21, 3, 5, 7, 1 }, array);

        //    _list.Unflattening();
        //    array = _list.GetArray();
        //    Assert.AreEqual(new int[] { 5, 33, 17, 2, 1, }, array);
        //}


        public void Test()
        {
            var e1 = new DLLElement(1);
            var e2 = new DLLElement(2);

            this.Change(ref e1, ref e2);
        }

        private void Change(ref DLLElement e1, ref DLLElement e2)
        {
            var temp = e1;

            e1 = e2;
            e2 = temp;
        }
    }
}
