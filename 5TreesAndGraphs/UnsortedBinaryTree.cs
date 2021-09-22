using System;
using System.Linq;

namespace _5TreesAndGraphs
{
    public class UnsortedBinaryTree : BinaryTreeAbstract
    {
        public Node CreateRoot(int value)
        {
            this.Root = new Node(value);
            return this.Root;
        }

        public Node ConnectRight(Node sourceNode, int targetValue)
        {
            var targetNode = new Node(targetValue);
            sourceNode.Right = targetNode;
            return targetNode;
        }

        public Node ConnectLeft(Node sourceNode, int targetValue)
        {
            var targetNode = new Node(targetValue);
            sourceNode.Left = targetNode;
            return targetNode;
        }

        public Node RotateRight(Node oldRoot)
        {
            var newRoot = oldRoot.Left;
            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;

            return newRoot;
        }

        /// <summary>
        /// Convert unsorted tree to Min heap binary tree.<br></br>
        /// Steps:<br></br>
        ///  -1 Convert unsorted binary tree to array<br></br>
        ///  -2 Sort Array<br></br>
        ///  -3 Re arange tree to a min heap binary tree<br></br>
        ///  Time complexity: <b>O(NlogN)</b>
        /// </summary>
        public Node ToMinHeap()
        {
            //O(N)
            var arrayLength = Traverse(this.Root, 0, null); //count nodes
            var array = new Node[arrayLength];

            //O(N)
            Traverse(this.Root, 0, array); //assign nodes to array

            //O(n log n)
            Array.Sort(array, (x, y) => x.Value - y.Value);

            //O(N)
            for (int i = 0; i < arrayLength; i++)
            {
                var leftIndex = 2 * i + 1;
                var rightIndex = 2 * i + 2;
                array[i].Left = leftIndex < arrayLength ? array[leftIndex] : null;
                array[i].Right = rightIndex < arrayLength ? array[rightIndex] : null;
            }

            this.Root = array[0];
            return this.Root;
        }

        private int Traverse(Node root, int count, Node[] array)
        {
            if (root == null) return count;
            if (array != null) array[count] = root;

            count++;
            count = Traverse(root.Left, count, array);
            count = Traverse(root.Right, count, array);

            return count;
        }
    }
}
