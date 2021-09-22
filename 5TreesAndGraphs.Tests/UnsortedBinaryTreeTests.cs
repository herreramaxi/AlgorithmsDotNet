using NUnit.Framework;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class UnsortedBinaryTreeTests
    {
        [Test]
        public void HeapifyUnsortedBinaryTree()
        {
            var unsortedBinaryTree = new UnsortedBinaryTree();
            var root = unsortedBinaryTree.CreateRoot(7);
            var node1 = unsortedBinaryTree.ConnectLeft(root,1);
            var node8 = unsortedBinaryTree.ConnectRight(root,8);
            unsortedBinaryTree.ConnectLeft(node1,6);
            unsortedBinaryTree.ConnectRight(node1,3);
            var node2= unsortedBinaryTree.ConnectLeft(node8,2);
            unsortedBinaryTree.ConnectRight(node8,5);
            unsortedBinaryTree.ConnectLeft(node2, 4);

            unsortedBinaryTree.ToMinHeap();

            var minHeap = new MinHeap();
            
            for (int i = 1; i <= 8; i++)
            {
                minHeap.Add(i);
            }

            Assert.AreEqual(minHeap.GetDotRepresentation(), unsortedBinaryTree.GetDotRepresentation());
        }
    }
}
