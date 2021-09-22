using System;
using System.Collections.Generic;
using System.Text;

namespace _5TreesAndGraphs
{
    public class MaxHeap : MinHeap
    {
        protected override void HeapifyDown()
        {
            var index = 0;

            while (HasLeftChild(index)) {
                var biggerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index)) {
                    biggerIndex = GetRightChildIndex(index);
                }

                if (_elements[index] > _elements[biggerIndex])
                    break;

                Swap(index, biggerIndex);
                index = biggerIndex;
            }
        }

        protected override void HeapifyUp()
        {
            var index = _size - 1;

            while (!IsRoot(index) && _elements[index] > GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}
