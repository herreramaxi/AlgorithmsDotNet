using System;
using System.Collections.Generic;

namespace _4LinkedLists
{
    public class StackAsSinglyLinkedList
    {
        public Element Head { get; set; }

        private List<Element> _list = new List<Element>();

        public void Push(int data)
        {
            //_list.InsertFirst(data);
            var element = new Element(this.Head, data);
            this.Head = element;
        }

        public int Pop()
        {
            var element = this.Head;
            if (element == null) throw new Exception("Empty stack");

            this.Head = this.Head.Next;

            return element.Data;
        }

        public int Peek()
        {
            var first = this.Head;

            if (first == null)
                throw new Exception("empty stack");

            return first.Data;
        }

        public int Count()
        {
            var pointer = this.Head;
            var count = 0;
            while (pointer != null)
            {
                count++;
                pointer = pointer.Next;
            }

            return count;

        }
    }
}
