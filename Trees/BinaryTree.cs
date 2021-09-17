using System;

namespace Trees
{
    public class BinaryTree
    {
        public BTNode Root { get; set; }
    
        public bool isEmpty()
        {
            return Root == null;
        }

        public void insertNode(BTNode startNode, BTNode newNode)
        {
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            if (newNode.Element > startNode.Element)
            {
                //right
                if (startNode.RightChild == null)
                {
                    startNode.RightChild=newNode;
                }
                else
                {
                    insertNode(startNode.RightChild, newNode);
                }
            }
            else if (newNode.Element < startNode.Element)
            {
                //left

                if (startNode.LeftChild == null)
                {
                    startNode.LeftChild= newNode;
                }
                else
                {
                    insertNode(startNode.LeftChild, newNode);
                }
            }
            else
            {
                Console.WriteLine("The node was already inserted: " + newNode.Element);
            }
        }

        public BTNode search(int searchTerm, BTNode startNode)
        {
            if (startNode == null)
            {
                return null;
            }

            if (searchTerm == startNode.Element)
            {
                return startNode;
            }

            return search(searchTerm,
                    searchTerm < startNode.Element
                    ? startNode.LeftChild
                    : startNode.RightChild);
        }

        /// <summary>
        /// root, left, right    
        /// </summary>
        /// <param name="theStart"></param>
        public void preOrderTraversal(BTNode theStart)
        {
            if (theStart == null)
            {
                return;
            }

            Console.WriteLine("Node: " + theStart.Element);
            preOrderTraversal(theStart.LeftChild);
            preOrderTraversal(theStart.RightChild);
        }

        /// <summary>
        /// left, root, right
        /// </summary>
        /// <param name="theStart"></param>
        public void inOrderTraversal(BTNode theStart)
        {           
            if (theStart == null)
            {
                return;
            }

            inOrderTraversal(theStart.LeftChild);
            Console.WriteLine("Node: " + theStart.Element);
            inOrderTraversal(theStart.RightChild);
            //        Console.WriteLine("Node: " + theStartElement);
        }

        /// <summary>
        /// left, right, root
        /// </summary>
        /// <param name="theStart"></param>
        public void postOrderTraversal(BTNode theStart)
        {
           
            if (theStart == null)
            {
                return;
            }

            postOrderTraversal(theStart.LeftChild);
            postOrderTraversal(theStart.RightChild);
            Console.WriteLine("Node: " + theStart.Element);
        }

        public int countNodes(BTNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + this.countNodes(node.LeftChild) + this.countNodes(node.RightChild);
        }

        public int height(BTNode node)
        {
            if (node == null || node.isExternal())
            {
                return 0;
            }

            int leftChildH = height(node.LeftChild);
            int rightChildH = height(node.RightChild);
            return 1 + Math.Max(leftChildH, rightChildH);
        }
    }

}
