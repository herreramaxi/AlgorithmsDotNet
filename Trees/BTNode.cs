namespace Trees
{
    public class BTNode
   {
        public int Element { get; set; }
        public BTNode LeftChild { get; set; }
        public BTNode RightChild { get; set; }
     
        public BTNode(int element)
        {
            this.Element = element;
        }

        public BTNode(int element, BTNode leftChild, BTNode rightChild)
        {
            this.Element = element;
            this.LeftChild = leftChild;
            this.RightChild= rightChild;
        }

        public bool isLeaft()
        {
            return LeftChild== null && RightChild == null;
        }

        public bool isInternal()
        {
            return LeftChild!= null || RightChild != null;
        }

        public bool isExternal()
        {
            return !this.isInternal();
        }
    }

}
