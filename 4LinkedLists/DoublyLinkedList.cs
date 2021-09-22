using System;
using System.Collections.Generic;

namespace _4LinkedList
{
    public class DoublyLinkedList
    {
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

            if (this.Head != null)
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
            if (this.Head == element)            
            {
                RemoveFirst();
                return;
            }

            if (this.Tail == element)
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

        private void Append(DLLElement child, DLLElement tail)
        {
            tail.Next = child;
            child.Prev = tail;

            var current = child;
            for (; current.Next != null; current = current.Next) ;

            this.Tail = current;
        }

        public void Unflattening()
        {
            var start = this.Head;

            ExploreAndSeparate(start);

            //Update the tail pointer
            var curNode = start;
            for (; curNode.Next != null; curNode = curNode.Next) ;

            this.Tail = curNode;
        }

        private void ExploreAndSeparate(DLLElement childListStart)
        {
            var curNode = childListStart;

            while (curNode != null)
            {
                if (curNode.Child != null)
                {
                    if (curNode.Child.Prev != null)
                    {
                        //terminates the child list before the child
                        curNode.Child.Prev.Next = null;
                        //starts the child list beginning with the child
                        curNode.Child.Prev = null;
                    }

                    ExploreAndSeparate(curNode.Child);
                }

                curNode = curNode.Next;
            }
        }

        public void FlattenList2()
        {
            var current = this.Head;

            while (current != null)
            {
                Append2(current);

                current = current.Next;
            }
        }

        public void FlattenList3()
        {
            var current = this.Head;
            FlattenList3Recursive(current);
        }

        private DLLElement FlattenList3Recursive(DLLElement head)
        {
            if (head == null) return null;

            var current = head;

            while (current.Next != null)
            {
                if (current.Child != null)
                {
                    var childTail = FlattenList3Recursive(current.Child);

                    childTail.Next = current.Next;
                    current.Next.Prev = childTail;
                    current.Next = current.Child;
                    current.Child.Prev = current;
                    current = childTail.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            if (current.Child != null)
            {
                var childTail = FlattenList3Recursive(current.Child);
                current.Next = current.Child;
                current.Child.Prev = current;

                return childTail;
            }

            return current;
        }

        private void Append2(DLLElement current)
        {
            if (current.Child == null) return;

            var curPos = current.Child;
            while (curPos.Next != null)
            {
                Append2(curPos);

                curPos = curPos.Next;
            }

            var next = current.Next;
            current.Next = current.Child;
            current.Child.Prev = current;
            next.Prev = curPos;
            curPos.Next = next;

            current.Child = null;
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

        public DLLElement InsertChild(int data)
        {
            var element = new DLLElement(data);
            this.Child = element;

            return element;
        }
    }
}
