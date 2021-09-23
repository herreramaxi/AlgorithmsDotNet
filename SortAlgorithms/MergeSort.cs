using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithms
{
    /// <summary>
    ///Class	Sorting algorithm
    ///Data structure	Array
    ///<b>Worst-case performance</b>	 O(nlog n)
    ///<b>Best-case performance</b>	 \Omega (nlog n)} typical, \Omega (n) natural variant
    ///<b>Average performance</b>	 \Theta (nlog n)
    ///<b>Worst-case space complexity</b>	 O(n) total with  O(n) auxiliary,  O(1) auxiliary with linked lists[1]
    /// </summary>
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int start, int end)
        {
            if (start >= end) return;

            var mid = (start + end) / 2;

            Sort(array, start, mid);
            Sort(array, mid + 1, end);
            Merge(array, start, mid, end);

        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int i = left;
            int j = middle + 1;
            int tempIndex = 0;

            var tempArray = new int[array.Length];

            while (i <= middle && j <= right)
            {
                if (array[i] < array[j])
                {
                    tempArray[tempIndex]=array[i];
                    i++;
                }
                else
                {
                    tempArray[tempIndex] = array[j];
                    j++;
                }

                tempIndex++;
            }

            while (i <= middle)
            {
                tempArray[tempIndex] = array[i++];
                tempIndex++;
            }

            while (j <= right)
            {
                tempArray[tempIndex] = array[j++];
                tempIndex++;
            }

            for (i = left, tempIndex = 0; i <= right; i++, tempIndex++)
            {
               array[i]= tempArray[tempIndex];
            }
        }
    }
}
