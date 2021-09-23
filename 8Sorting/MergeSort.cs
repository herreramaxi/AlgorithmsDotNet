using System;
using System.Collections.Generic;
using System.Text;

namespace _8Sorting
{
    public class MergeSort
    {

        /// <summary>
        /// Time complexity: n*log(n)<br></br>
        /// Space complexity: n
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] MergeSortSimple(int[] data)
        {
            if (data.Length < 2) return data;

            //Split array into 2 subarrays of approx equal size.
            var mid = data.Length / 2;
            var left = new int[mid];
            var right = new int[data.Length - mid];

            Array.Copy(data, 0, left, 0, left.Length);
            Array.Copy(data, mid, right, 0, right.Length);

            //Sort each subarray, then merge the result
            MergeSortSimple(left);
            MergeSortSimple(right);

            return Merge(data, left, right);
        }

        private static int[] Merge(int[] data, int[] left, int[] right)
        {
            var destIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    data[destIndex++] = left[leftIndex++];
                }
                else
                {
                    data[destIndex++] = right[rightIndex++];
                }
            }

            //Copy rest of whichever array remains
            while (leftIndex < left.Length)
            {
                data[destIndex++] = left[leftIndex++];
            }
            while (rightIndex < right.Length)
            {
                data[destIndex++] = right[rightIndex++];
            }

            return data;
        }

        public static int[] MergeSort2(int[] array)
        {
            MergeSort2(array, 0, array.Length - 1);
            return array;
        }

        //O(NlogN)
        private static void MergeSort2(int[] array, int start, int end)
        {
            if (start >= end) return;

            var mid = (start + end) / 2;
            //var mid = start + (end-start)/2;
            MergeSort2(array, start, mid);
            MergeSort2(array, mid + 1, end);
            Merge2(array, start, mid, end);
        }

        //O(N)
        private static void Merge2(int[] array, int left, int middle, int right)
        {
            var i = left;
            var j = middle + 1;
            var tempIndex = 0;
            var tempArray = new int[array.Length];

            while (i <= middle && j <= right)
            {
                if (array[i] < array[j])
                {
                    tempArray[tempIndex++] = array[i++];
                }
                else
                {
                    tempArray[tempIndex++] = array[j++];
                }
            }

            while (i <= middle)
            {
                tempArray[tempIndex++] = array[i++];
            }

            while (j <= right)
            {
                tempArray[tempIndex++] = array[j++];
            }
                      
            for ( i = left, tempIndex=0; i <= right; i++, tempIndex++)
            {
                array[i] = tempArray[tempIndex];
            }
        }
    }
}
