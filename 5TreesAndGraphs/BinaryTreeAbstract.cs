using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _5TreesAndGraphs
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class BinaryTreeAbstract
    {
        private string DebuggerDisplay => GetDotRepresentation();
        public Node Root { get; set; }

        public string GetDotRepresentation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("digraph BST {");
            GetDotRepresentation(this.Root, sb);
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Returns zero-based height for the tree. The root's height is zero.
        /// O(n) time complexity
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return this.Height(Root);
        }
        public int Height(Node node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(this.Root);
        }
        public void InOrderTraversal()
        {
            InOrderTraversal(this.Root);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(this.Root);
        }

        private void PreOrderTraversal(Node root)
        {
            if (root == null) return;

            Console.Write($"{root.Value},");
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        private void InOrderTraversal(Node root)
        {
            if (root == null) return;

            InOrderTraversal(root.Left);
            Console.Write($"{root.Value},");
            InOrderTraversal(root.Right);
        }

        private void PostOrderTraversal(Node root)
        {
            if (root == null) return;

            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.Write($"{root.Value},");
        }

        /// <summary>
        /// Root, left, right
        /// </summary>
        public void PreOrderTraversalWithStack()
        {
            var stack = new Stack<Node>();

            stack.Push(this.Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                Console.Write($"{node.Value},");

                if (node.Right != null)
                    stack.Push(node.Right);

                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        /// <summary>
        /// left, root, right
        /// </summary>
        public void InOrderTraversalWithStack()
        {
            var stack = new Stack<Node>();
            var current = this.Root;

            while (current != null || stack.Count > 0)
            {
                //Reach the left most node of the current node
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    //current must be null at this point
                    current = stack.Pop();
                    Console.Write($"{current.Value},");
                    current = current.Right;
                }
            }
        }

        /// <summary>
        /// left, right, root
        /// </summary>
        public void PostOrderTraversalWithStack()
        {
            var stack = new Stack<Node>();
            stack.Push(this.Root);

            //stack for store postorder traversal
            var output = new Stack<int>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                output.Push(current.Value);

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
            }

            while (output.Count > 0)
            {
                Console.Write($"{output.Pop()},");
            }
        }

        private void GetDotRepresentation(Node root, StringBuilder sb)
        {
            if (root == null) return;

            if (root.Left != null)
            {
                sb.AppendLine($"{root.Value} -> {root.Left.Value}");
            }

            if (root.Right != null)
            {
                sb.AppendLine($"{root.Value} -> {root.Right.Value}");
            }

            GetDotRepresentation(root.Left, sb);
            GetDotRepresentation(root.Right, sb);
        }
    }
}
