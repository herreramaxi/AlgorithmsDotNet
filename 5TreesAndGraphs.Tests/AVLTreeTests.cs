using NUnit.Framework;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class AVLTreeTests
    {
        [Test]
        public void TestAVL()
        {
            var tree = new AVLTree(true);
            tree.Insert(13);
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(16);
            tree.Insert(11);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);

            var balance = tree.GetBalance(tree.Root);

            tree.Insert(3);
            var balanceAfter = tree.GetBalance(tree.Root);

            var tree2 = new AVLTree();
            tree2.Insert(13);
            tree2.Insert(10);
            tree2.Insert(15);
            tree2.Insert(16);
            tree2.Insert(11);
            tree2.Insert(5);
            tree2.Insert(8);
            tree2.Insert(4);

            var balance2 = tree2.GetBalance(tree2.Root);

            tree2.Insert(3);
            var balanceAfter2 = tree2.GetBalance(tree2.Root);

        }
    }
}
