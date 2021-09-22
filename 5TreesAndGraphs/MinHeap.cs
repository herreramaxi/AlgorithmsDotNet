using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _5TreesAndGraphs
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class MinHeap
    {
        protected int[] _elements;
        protected int _capacity;
        protected int _size;

        private string DebuggerDisplay => GetDotRepresentation();
        public string GetDotRepresentation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("digraph BST {");
            GetDotRepresentation(0, sb);
            sb.AppendLine("}");

            return sb.ToString();
        }

        private void GetDotRepresentation(int index, StringBuilder sb)
        {
            if (index>= _size) return;

            if (HasLeftChild(index))
            {
                sb.AppendLine($"{_elements[index]} -> {GetLeftChild(index)}");
            }

            if (HasRightChild(index))
            {
                sb.AppendLine($"{_elements[index]} -> {GetRightChild(index)}");
            }

            GetDotRepresentation(GetLeftChildIndex(index), sb);
            GetDotRepresentation(GetRightChildIndex(index), sb);
        }

        public MinHeap(int capacity = 10)
        {
            _elements = new int[capacity];
            _capacity = capacity; ;
        }
        
        public bool IsEmpty() => _size == 0;

        public int[] GetArray()
        {
            var array = new int[_size];
            Array.Copy(_elements, array, _size );

            return array;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("Heap is empty");

            return _elements[0];
        }
        
        public int Pop()
        {
            if (IsEmpty())
                throw new Exception("Heap is empty");

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            HeapifyDown();

            return result;
        }

        public void Add(int value)
        {
            if (_capacity == _size)
            {
                _capacity *= 2;
                Array.Copy(_elements, _elements, _capacity);
            }

            _elements[_size++] = value;

            HeapifyUp();
        }

        protected virtual void HeapifyUp()
        {
            var index = _size - 1;

            while (!IsRoot(index) && _elements[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        protected virtual void HeapifyDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        /// <summary>
        /// root, left, right    
        /// </summary>
        /// <param name="theStart"></param>
        public void PreOrderTraversal(int index)
        {
            if (index >= _size)
            {
                return;
            }

            Console.WriteLine("Node: " + _elements[index]);
            PreOrderTraversal(GetLeftChildIndex(index));
            PreOrderTraversal(GetRightChildIndex(index));
        }

        public void Print()
        {
            if (_size == 0)
            {
                Console.WriteLine("Empty heap"); return;
            }

            PreOrderTraversal(0);
        }

        public void PrintByLevels()
        {
            if (_size == 0)
            {
                Console.WriteLine("Empty heap"); return;
            }           

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < Math.Pow(2, i) && j + Math.Pow(2, i) <= _size; j++)
                {
                   Console.Write(_elements[j + (int)Math.Pow(2, i) - 1] + " ");
                }

                Console.WriteLine();
            }
        }

        public void PrintAsArray()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.Write(_elements[i]+ ", ");
            }
        }

        public int GetHeight()
        {
            return Convert.ToInt32(Math.Floor(Math.Log2(_size))) + 1;
        }

        protected int GetLeftChildIndex(int index) => 2 * index + 1;
        protected int GetRightChildIndex(int index) => 2 * index + 2;
        protected int GetParentIndex(int index) => (index - 1) / 2;
        protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
        protected bool HasRightChild(int index) => GetRightChildIndex(index) < _size;
        protected bool IsRoot(int index) => index == 0;
        protected int GetLeftChild(int index) => _elements[GetLeftChildIndex(index)];
        protected int GetRightChild(int index) => _elements[GetRightChildIndex(index)];
        protected int GetParent(int index) => _elements[GetParentIndex(index)];
        protected void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }
    }
}
