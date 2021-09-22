using NUnit.Framework;
using System;
using System.IO;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class Tests
    {
        private BinaryTree _bt;

        [SetUp]
        public void Setup()
        {
            _bt = new BinaryTree();
            _bt.Insert(50);
            _bt.Insert(25);
            _bt.Insert(75);
            _bt.Insert(12);
            _bt.Insert(30);
            _bt.Insert(60);
            _bt.Insert(80);
            _bt.Insert(90);
        }

        [Test]
        public void TestFindNode()
        {
            Assert.AreEqual(50, _bt.FindNode(50).Value);
            Assert.AreEqual(12, _bt.FindNode(12).Value);
            Assert.AreEqual(90, _bt.FindNode(90).Value);
            Assert.IsNull(_bt.FindNode(100));
            Assert.IsNull(_bt.FindNode(-1));
        }

        [Test]
        public void TestFindNodeR()
        {
            Assert.AreEqual(50, _bt.FindNodeR(50).Value);
            Assert.AreEqual(12, _bt.FindNodeR(12).Value);
            Assert.AreEqual(90, _bt.FindNodeR(90).Value);
            Assert.IsNull(_bt.FindNodeR(100));
            Assert.IsNull(_bt.FindNodeR(-1));
        }

        [Test]
        public void TestBFS()
        {
            Assert.AreEqual(50, _bt.BFS(50).Value);
            Assert.AreEqual(12, _bt.BFS(12).Value);
            Assert.AreEqual(90, _bt.BFS(90).Value);
            Assert.IsNull(_bt.BFS(100));
            Assert.IsNull(_bt.BFS(-1));
        }

        [Test]
        public void TestBFSWithQueue()
        {
            Assert.AreEqual(50, _bt.BFSWithQueue(50).Value);
            Assert.AreEqual(12, _bt.BFSWithQueue(12).Value);
            Assert.AreEqual(90, _bt.BFSWithQueue(90).Value);
            Assert.IsNull(_bt.BFSWithQueue(100));
            Assert.IsNull(_bt.BFSWithQueue(-1));
        }

        [Test]
        public void TestDFSPreOrder()
        {
            Assert.AreEqual(50, _bt.DFSPreOrder(50).Value);
            Assert.AreEqual(12, _bt.DFSPreOrder(12).Value);
            Assert.AreEqual(90, _bt.DFSPreOrder(90).Value);
            Assert.IsNull(_bt.DFSPreOrder(100));
            Assert.IsNull(_bt.DFSPreOrder(-1));
        }

        [Test]
        public void TestDFSInOrder()
        {
            Assert.AreEqual(50, _bt.DFSInOrder(50).Value);
            Assert.AreEqual(12, _bt.DFSInOrder(12).Value);
            Assert.AreEqual(90, _bt.DFSInOrder(90).Value);
            Assert.IsNull(_bt.DFSInOrder(100));
            Assert.IsNull(_bt.DFSInOrder(-1));
        }

        [Test]
        public void TestDFSPostOrder()
        {
            Assert.AreEqual(50, _bt.DFSPostOrder(50).Value);
            Assert.AreEqual(12, _bt.DFSPostOrder(12).Value);
            Assert.AreEqual(90, _bt.DFSPostOrder(90).Value);
            Assert.IsNull(_bt.DFSPostOrder(100));
            Assert.IsNull(_bt.DFSPostOrder(-1));
        }

        [Test]
        public void TestHeight()
        {
            Assert.AreEqual(3, _bt.Height());
        }

        [Test]
        public void TestPreOrderTraversalRecursive()
        {

            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.PreOrderTraversal();

            Assert.AreEqual("50,25,12,30,75,60,80,90,", sw.ToString());
        }

        [Test]
        public void TestPreOrderTraversalStack()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.PreOrderTraversalWithStack();

            Assert.AreEqual("50,25,12,30,75,60,80,90,", sw.ToString());
        }

        [Test]
        public void TestInOrderTraversalRecursive()
        {

            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.InOrderTraversal();

            Assert.AreEqual("12,25,30,50,60,75,80,90,", sw.ToString());
        }

        [Test]
        public void TestInOrderTraversalStack()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.InOrderTraversalWithStack();

            Assert.AreEqual("12,25,30,50,60,75,80,90,", sw.ToString());
        }

        [Test]
        public void TestPostOrderTraversalRecursive()
        {

            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.PostOrderTraversal();

            Assert.AreEqual("12,30,25,60,90,80,75,50,", sw.ToString());
        }

        [Test]
        public void TestPostOrderTraversalStack()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _bt.PostOrderTraversalWithStack();

            Assert.AreEqual("12,30,25,60,90,80,75,50,", sw.ToString());
        }

        [Test]
        public void TestLowestCommonAncestor()
        {           
            var bt = new BinaryTree();
            bt.Insert(20);
            bt.Insert(8);
            bt.Insert(22);
            bt.Insert(4);
            bt.Insert(12);
            bt.Insert(10);
            bt.Insert(14);
            bt.Insert(30);
            bt.Insert(21);
            bt.Insert(25);
            bt.Insert(45);

            Assert.AreEqual(8, bt.LowestCommonAncestor(4, 14).Value);
            Assert.AreEqual(20, bt.LowestCommonAncestor(10, 30).Value);
            Assert.AreEqual(22, bt.LowestCommonAncestor(21, 45).Value);
        }

        [Test]
        public void TestLowestCommonAncestorRecursive()
        {
            var bt = new BinaryTree();
            bt.Insert(20);
            bt.Insert(8);
            bt.Insert(22);
            bt.Insert(4);
            bt.Insert(12);
            bt.Insert(10);
            bt.Insert(14);
            bt.Insert(30);
            bt.Insert(21);
            bt.Insert(25);
            bt.Insert(45);

            Assert.AreEqual(8, bt.LowestCommonAncestorRecursive(4, 14).Value);
            Assert.AreEqual(20, bt.LowestCommonAncestorRecursive(10, 30).Value);
            Assert.AreEqual(22, bt.LowestCommonAncestorRecursive(21, 45).Value);
        }
    }
}