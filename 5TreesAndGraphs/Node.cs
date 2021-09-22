using System;

namespace _5TreesAndGraphs
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public Node(Node left, Node right, int value)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public Node(int value)
        {
            Value = value;
        }       
    }
}
