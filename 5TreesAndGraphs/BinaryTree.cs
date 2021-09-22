using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace _5TreesAndGraphs
{
    public class BinaryTree : BinaryTreeAbstract
    {
        public void Insert(int value)
        {
            this.Root = Insert(this.Root, value);
        }

        public Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value); ;
            }
            else if (value < root.Value)
            {
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        public Node FindNode(int value)
        {
            return FindNode(this.Root, value);
        }

        /// <summary>
        /// O(logN)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node FindNode(Node root, int value)
        {
            while (root != null)
            {
                var curValue = root.Value;
                if (value == curValue) break;

                root = value < curValue ? root.Left : root.Right;
            }

            return root;
        }

        public Node FindNodeR(int value)
        {
            return FindNodeR(this.Root, value);
        }

        public Node FindNodeR(Node root, int value)
        {
            if (root == null) return null;
            if (value == root.Value) return root;

            if (value < root.Value)
            {
                return FindNodeR(root.Left, value);
            }
            else
            {
                return FindNodeR(root.Right, value);
            }
        }

        /// <summary>
        /// Time complexity: O(n^2)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node BFS(int key)
        {
            var height = this.Height();

            for (int i = 1; i <= height + 1; i++)
            {
                var node = SearchCurrentLevel(this.Root, i, key);

                if (node != null)
                    return node;
            }

            return null;
        }

        public void BFSPrint()
        {
            var height = this.Height();

            for (int i = 1; i <= height + 1; i++)
            {
                PrintCurrentLevel(this.Root, i);
                Console.WriteLine();
            }
        }

        private void PrintCurrentLevel(Node root, int level)
        {
            if (root == null || level <= 0) return;
            if (level == 1) Console.Write($"{root.Value}\t");

            PrintCurrentLevel(root.Left, level - 1);
            PrintCurrentLevel(root.Right, level - 1);
        }

        /// <summary>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node BFSWithQueue(int key)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var dequeued = queue.Dequeue();

                if (dequeued == null) continue;

                if (dequeued.Value == key)
                    return dequeued;

                queue.Enqueue(dequeued.Left);
                queue.Enqueue(dequeued.Right);
            }

            return null;
        }

        public void BalaceBST()
        {
            //Get inorder array
            var nodes = new List<Node>();
             GetInOrderArray(this.Root, nodes);

            //build bst from array
            this.SortedArrayToBST(nodes.Select(x => x.Value).ToArray());
        }

        private void GetInOrderArray(Node root, List<Node> nodes)
        {
            if (root == null) return;

            GetInOrderArray(root.Left, nodes);
            nodes.Add(root);
            GetInOrderArray(root.Right, nodes);
        }


        /// <summary>
        /// Depth-First Search in Pre order (root, left, right)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node DFSPreOrder(int key)
        {
            return DFSPreOrder(this.Root, key);
        }

        /// <summary>
        /// Depth-First Search in in-order (left, root, right)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node DFSInOrder(int key)
        {
            return DFSInOrder(this.Root, key);
        }

        /// <summary>
        /// Depth-First Search in post-order (left, right, root)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node DFSPostOrder(int key)
        {
            return DFSPostOrder(this.Root, key);
        }

        private Node SearchCurrentLevel(Node root, int level, int key)
        {
            if (root == null || level == 0)
                return null;

            if (level == 1)
            {
                return root.Value == key ? root : null;
            }

            var nodeLeft = SearchCurrentLevel(root.Left, level - 1, key);
            if (nodeLeft != null) return nodeLeft;

            var nodeRight = SearchCurrentLevel(root.Right, level - 1, key);
            if (nodeRight != null) return nodeRight;

            return null;
        }

        private Node DFSPreOrder(Node root, int key)
        {
            if (root == null) { return null; }

            if (root.Value == key) return root;

            var leftSearch = DFSPreOrder(root.Left, key);
            if (leftSearch != null) return leftSearch;

            var rightSearch = DFSPreOrder(root.Right, key);
            if (rightSearch != null) return rightSearch;

            return null;
        }

        private Node DFSInOrder(Node root, int key)
        {
            if (root == null) { return null; }

            var leftSearch = DFSInOrder(root.Left, key);
            if (leftSearch != null) return leftSearch;

            if (root.Value == key) return root;

            var rightSearch = DFSInOrder(root.Right, key);
            if (rightSearch != null) return rightSearch;

            return null;
        }

        private Node DFSPostOrder(Node root, int key)
        {
            if (root == null) { return null; }

            var leftSearch = DFSPostOrder(root.Left, key);
            if (leftSearch != null) return leftSearch;

            var rightSearch = DFSPostOrder(root.Right, key);
            if (rightSearch != null) return rightSearch;

            if (root.Value == key) return root;

            return null;
        }

        public Node LowestCommonAncestor(int value1, int value2)
        {
            return LowestCommonAncestor(this.Root, value1, value2);
        }

        /// <summary>
        /// Time complexity: O(N)
        /// Space complexity: O(N)
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public Node LowestCommonAncestorRecursive(int value1, int value2)
        {
            return LowestCommonAncestorRecursive(this.Root, value1, value2);
        }

        private Node LowestCommonAncestorRecursive(Node root, int value1, int value2)
        {
            if (root == null) return null;
            if (root.Value == value1 || root.Value == value2) return root;

            var left = LowestCommonAncestorRecursive(root.Left, value1, value2);
            var right = LowestCommonAncestorRecursive(root.Right, value1, value2);

            if (left == null)
            {
                return right;
            }
            else if (right == null)
            {
                return left;
            }
            else
            {
                return root;
            }
        }

        /// <summary>
        /// returns the lowest common ancestor given a root node and two node values. 
        /// There is no verification of existence of value1 and value2
        /// Time complexity: O(logN)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        private Node LowestCommonAncestor(Node root, int value1, int value2)
        {
            if (root == null) return null;

            var current = root;

            while (current != null)
            {
                if (current.Value > value1 && current.Value > value2)
                {
                    current = current.Left;
                }
                else if (current.Value < value1 && current.Value < value2)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }

            return null;
        }

        public Node SortedArrayToBST(int[] array)
        {
            this.Root = SortedArrayToBST(array, 0, array.Length - 1);

            return this.Root;
        }

        private Node SortedArrayToBST(int[] array, int start, int end)
        {
            if (start > end) return null;

            var middle = (start + end) / 2;
            var node = new Node(array[middle]);

            node.Left = SortedArrayToBST(array, start, middle - 1);
            node.Right = SortedArrayToBST(array, middle + 1, end);

            return node;
        }
    }
}
