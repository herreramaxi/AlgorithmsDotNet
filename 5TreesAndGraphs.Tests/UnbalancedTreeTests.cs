using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class UnbalancedTreeTests
    {
        [Test]
        public void Test1()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var ubt = new UnsortedBinaryTree();
            var root = ubt.CreateRoot(12);
            ubt.ConnectRight(root, 13);
            var n10 = ubt.ConnectLeft(root, 10);
            ubt.ConnectRight(n10, 11);
            var n8 = ubt.ConnectLeft(n10, 8);
            ubt.ConnectRight(n8, 9);
            var n6 = ubt.ConnectLeft(n8, 6);
            ubt.ConnectRight(n6, 7);
            var n4 = ubt.ConnectLeft(n6, 4);
            ubt.ConnectRight(n4, 5);
            var n2 = ubt.ConnectLeft(n4, 2);
            ubt.ConnectRight(n2, 3);
            ubt.ConnectLeft(n2, 1);
            //ubt.PreOrderTraversal();
                     
            Console.WriteLine("Height: " + ubt.Height());
            Console.WriteLine("Height left: " + ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

            ubt.Root = ubt.RotateRight(ubt.Root);
            Console.WriteLine("Height: " +ubt.Height());
            Console.WriteLine("Height left: " +ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

            ubt.Root = ubt.RotateRight(ubt.Root);
            Console.WriteLine("Height: " + ubt.Height());
            Console.WriteLine("Height left: " + ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

            ubt.Root = ubt.RotateRight(ubt.Root);
            Console.WriteLine("Height: " + ubt.Height());
            Console.WriteLine("Height left: " + ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

            ubt.Root = ubt.RotateRight(ubt.Root);
            Console.WriteLine("Height: " + ubt.Height());
            Console.WriteLine("Height left: " + ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

            ubt.Root = ubt.RotateRight(ubt.Root);
            Console.WriteLine("Height: " + ubt.Height());
            Console.WriteLine("Height left: " + ubt.Height(ubt.Root.Left));
            Console.WriteLine("Height right: " + ubt.Height(ubt.Root.Right));

        }

        [Test]
        public void BuildBSTFromSortedArrayTest() {

            using var sw = new StringWriter();
            Console.SetOut(sw);
            var bt = new BinaryTree();
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            var root = bt.SortedArrayToBST(array );
            bt.InOrderTraversal();

            Assert.AreEqual("1,2,3,4,5,6,7,", sw.ToString());
        }

        [Test]
        public void BalanceUnbalancedBST()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            var bt = new BinaryTree();
            bt.Insert(6);
            bt.Insert(7);
            bt.Insert(4);
            bt.Insert(5);
            bt.Insert(2);
            bt.Insert(3);
            bt.Insert(1);

            bt.BalaceBST();         
            bt.InOrderTraversal();

            Assert.AreEqual("1,2,3,4,5,6,7,", sw.ToString());
        }

    }
}
