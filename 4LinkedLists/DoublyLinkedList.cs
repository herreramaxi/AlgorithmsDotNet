using System;
using System.Collections.Generic;

namespace _4LinkedList
{
    public class DoublyLinkedList
    {
        private List<DLLElement> _list = new List<DLLElement>();
        public DLLElement Head { get; set; }
        public DLLElement Tail { get; set; }
        public void InsertFirst(int data)
        {
            var element = new DLLElement(data);

            if (this.Head == null)
            {
                this.Head = element;
                this.Tail = element;
                return;
            }

            var next = this.Head;
            element.Next = next;
            next.Prev = element;
            this.Head = element;
        }

        public void InsertLast(int data)
        {
            if (this.Tail == null)
            {
                InsertFirst(data);
                return;
            }

            var element = new DLLElement(data);
            element.Prev = this.Tail;
            element.Prev.Next = element;
            this.Tail = element;
        }

        public void InsertAfter(DLLElement before, int data)
        {
            if (this.Head == null) throw new Exception("List empty");
            if (before == null) throw new Exception("Before is null");

            var element = new DLLElement(data);

            //last element
            if (before.Next == null)
            {
                before.Next = element;
                element.Prev = before;
                this.Tail = element;
                return;
            }

            element.Next = before.Next;
            before.Next.Prev = element;
            before.Next = element;
            element.Prev = before;
        }

        public void RemoveFirst()
        {
            if (this.Head == null) throw new Exception("List empty");

            this.Head = this.Head.Next;
            this.Head.Prev = null;
        }

        public void RemoveLast()
        {
            if (this.Tail == null) throw new Exception("List empty");

            this.Tail = this.Tail.Prev;
            this.Tail.Next = null;
        }

        public void Remove(DLLElement element)
        {
            if (Object.ReferenceEquals(this.Head, element))
            {
                RemoveFirst();
                return;
            }

            if (Object.ReferenceEquals(this.Tail, element))
            {
                RemoveLast();
                return;
            }

            element.Prev.Next = element.Next;
            element.Next.Prev = element.Prev;
            element.Next = null;
            element.Prev = null;
        }

        public void FlattenList()
        {
            var current = this.Head;

            while (current != null)
            {
                if (current.Child != null)
                {
                    //I can't pass a reference to Tail because thre is a restriction for doing that in C#
                    Append(current.Child, this.Tail);
                }

                current = current.Next;
            }
        }

        private void Append(DLLElement child,  DLLElement tail)
        {
            tail.Next = child;
            child.Prev = tail;

            var current = child;
            for (; current.Next != null; current = current.Next) ;

            this.Tail = current;
        }

        public int[] GetArray()
        {
            var result = new List<int>();
            var pointer = this.Head;

            while (pointer != null)
            {
                result.Add(pointer.Data);
                pointer = pointer.Next;
            }

            return result.ToArray();
        }
    }

    public class DLLElement
    {
        public DLLElement(int data)
        {
            Data = data;
        }

        public int Data { get; set; }
        public DLLElement Next { get; set; }
        public DLLElement Prev { get; set; }
        //Multi-level doubly linked list
        public DLLElement Child { get; set; }

        public DLLElement InsertLast(int data)
        {
            var element = new DLLElement(data);
            this.Next = element;
            element.Prev = this;

            return element;
        }

        public DLLElement InsertChild(int data) {
            var element = new DLLElement(data);
            this.Child = element;

            return element;
        }
    }
}
