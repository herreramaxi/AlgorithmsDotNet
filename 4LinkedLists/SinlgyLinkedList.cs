using System;
using System.Collections.Generic;

namespace _4LinkedLists
{
    public class SinlgyLinkedList
    {
        public Element Head { get; set; }
        public Element InsertFirst(int data)
        {
            var element = new Element(this.Head, data);
            this.Head = element;

            return element;
        }

        public Element InsertLast(int data)
        {
            if (this.Head == null)
            {
                return InsertFirst(data);
            }

            var element = new Element(data);
            Element pointer = GetLast();
            pointer.Next = element;

            return element;
        }

        public int Count()
        {
            var count = 0;
            var pointer = this.Head;
            while (pointer != null)
            {
                count++;
                pointer = pointer.Next;
            }

            return count;
        }

        public Element InsertAfter(Element previousElement, int data)
        {
            if (previousElement == null)
                throw new ArgumentNullException();

            var element = new Element(previousElement.Next, data);
            previousElement.Next = element;

            return element;
        }

        public Element RemoveFirst()
        {
            var returnValue = this.Head;
            this.Head = this.Head?.Next;

            return returnValue;
        }

        public void RemoveLast()
        {
            if (this.Head == null) return;
            if (this.Head.Next == null)
            {
                RemoveFirst();
                return;
            }

            var pointer = this.Head;

            while (pointer?.Next?.Next != null)
            {
                pointer = pointer.Next;
            }

            pointer.Next = null;
        }


        public bool Remove(Element element)
        {
            if (element == null) return false;

            if (Object.ReferenceEquals(this.Head, element))
            {
                this.Head = this.Head.Next;
                return true;
            }

            var curPos = this.Head;

            while (curPos != null)
            {
                if (Object.ReferenceEquals(curPos.Next, element))
                {

                    curPos.Next = element.Next;
                    return true;
                }
                curPos = curPos.Next;
            }

            return false;
        }

        public Element GetLast()
        {
            var pointer = this.Head;

            while (pointer?.Next != null)
            {
                pointer = pointer.Next;
            }

            return pointer;
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

        public Element GetNthElement(int nth)
        {
            var curPos = this.Head;

            for (int i = nth; i > 0 && curPos != null; i--, curPos = curPos.Next) ;

            //while (curPos != null && nth > 0)
            //{
            //    curPos = curPos.Next;
            //    nth--;
            //}

            return curPos;
        }

        /// <summary>
        /// Returns Mth to last element. O(N)
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Element GetMthToLast(int m)
        {
            if (this.Head == null) return null;

            var curPos = this.Head;
            for (int i = 0; i < m; i++)
            {
                if (curPos.Next != null)
                {
                    curPos = curPos.Next;
                }
                else { return null; }
            }

            var behindPosition = this.Head;

            while (curPos.Next != null)
            {
                curPos = curPos.Next;
                behindPosition = behindPosition.Next;
            }

            return behindPosition;
        }

        public void Print()
        {
            var pointer = this.Head;
            Console.Write("[");
            while (pointer != null)
            {

                Console.Write($"{pointer.Data},");
                pointer = pointer.Next;
            }

            Console.Write("]");
        }
    }

    public class Element
    {
        public Element(int data)
        {
            Data = data;
        }

        public Element(Element next, int data)
        {
            Next = next;
            Data = data;
        }

        public int Data { get; set; }
        public Element Next { get; set; }
    }
}
