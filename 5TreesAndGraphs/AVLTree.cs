using System;
using System.Diagnostics;
using System.Text;

namespace _5TreesAndGraphs
{
    //Source: https://www.geeksforgeeks.org/avl-tree-set-1-insertion/
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class AVLTree
    {
        private bool _selfBalancingDisable;

        private string DebuggerDisplay => GetDotRepresentation();

        public string GetDotRepresentation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("digraph BST {");
            GetDotRepresentation(this.Root, sb);
            sb.AppendLine("}");

            return sb.ToString();
        }

        public NodeAVL Root { get; set; }

        public AVLTree(bool selfBalancingDisable = false)
        {
            _selfBalancingDisable = selfBalancingDisable;
        }

        public int Height(NodeAVL node)
        {
            if (node == null) return 0;

            return node.Height;
        }

        private int Max(int a, int b) => Math.Max(a, b);

        /// <summary>
        /// Right rotate subtree rooted with y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public NodeAVL RightRotate(NodeAVL y)
        {
            var x = y.Left;
            var t2 = x.Right;

            x.Right = y;
            y.Left = t2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right) + 1);
            x.Height = Math.Max(Height(x.Left), Height(x.Right) + 1);

            return x;
        }


        /// <summary>
        /// Left rotate subtree rooted with y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public NodeAVL LeftRotate(NodeAVL x)
        {
            var y = x.Right;
            var t2 = y.Left;

            y.Left = x;
            x.Right = t2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right) + 1);
            x.Height = Math.Max(Height(x.Left), Height(x.Right) + 1);

            return y;
        }

        public int GetBalance(NodeAVL node)
        {
            if (node == null) return 0;

            return Height(node.Left) - Height(node.Right);
        }

        public NodeAVL Insert(int key)
        {
            this.Root = Insert(this.Root, key);
            return this.Root;
        }

        public NodeAVL Insert(NodeAVL node, int key)
        {
            //1. Perform the normal BST insertion
            if (node == null) return new NodeAVL(key);

            if (key < node.Value)
            {
                node.Left = Insert(node.Left, key);
            }
            else if (key > node.Value)
            {
                node.Right = Insert(node.Right, key);
            }
            else return node;

            //2. Update height of this ancestor node
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            if (_selfBalancingDisable) return node;

            //3. Get the balance factor of this ancestor node to check wether this node became unbalanced
            var balance = GetBalance(node);

            //If this node becomes unbalanced, then there are 4 cases

            //left left case
            if (balance > 1 && key < node.Left.Value)
            {
                return RightRotate(node);
            }

            //left right
            if (balance > 1 && key > node.Right.Value)
            {
                node.Left = LeftRotate(node);
                return RightRotate(node);
            }

            //right right
            if (balance < -1 && key > node.Right.Value)
            {
                return LeftRotate(node);
            }

            //right left
            if (balance < -1 && key < node.Left.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private void GetDotRepresentation(NodeAVL root, StringBuilder sb)
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
