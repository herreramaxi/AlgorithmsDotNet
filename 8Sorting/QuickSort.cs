using System;

namespace _8Sorting
{
    public class QuickSort
    {
        /// <summary>
        /// Simple quicksort, pivot middle element
        /// Time complexity: Worst complexity: n^2, Average complexity: n* log(n), Best complexity: n* log(n)
        /// Space complexity: O(logn)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] QuickSortSimple(int[] data)
        {
            if (data.Length < 2) return data;

            var pivotIndex = data.Length / 2;
            var pivotValue = data[pivotIndex];
            var leftCount = 0;

            //count how many are less than the pivot
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < pivotValue)
                    leftCount++;
            }

            //allocate the array and create the subsets
            var left = new int[leftCount];
            var right = new int[data.Length - leftCount - 1];

            var l = 0;
            var r = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (i == pivotIndex) continue;

                var val = data[i];

                if (val < pivotValue)
                {
                    left[l++] = val;
                }
                else
                {
                    right[r++] = val;
                }
            }

            //Sort the subsets
            left = QuickSortSimple(left);
            right = QuickSortSimple(right);

            //combine the sorted arrays and the pivot back into the original array
            Array.Copy(left, 0, data, 0, left.Length);
            data[left.Length] = pivotValue;
            Array.Copy(right, 0, data, left.Length + 1, right.Length);

            return data;
        }


        /// <summary>
        /// Quick sort, last element as pivot. Lomuto partition.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        public static int[] QuickSortLastElement(int[] array)
        {
            QuickSortLastElement(array, 0, array.Length - 1);
            return array;
        }

        public static void QuickSortLastElement(int[] array, int lo, int hi)
        {
            if (lo < 0 || hi < 0 || hi < lo) return;

            var p = PartitionLastElement(array, lo, hi);
            QuickSortLastElement(array, lo, p - 1);
            QuickSortLastElement(array, p + 1, hi);
        }

        private static int PartitionLastElement(int[] array, int lo, int hi)
        {
            var pivot = array[hi];
            var i = lo - 1;

            for (int j = lo; j <= hi; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            return i;
        }

        public static int[] QuickSortMiddleElement(int[] array)
        {
            QuickSortMiddleElement(array, 0, array.Length - 1);
            return array;
        }

        private static void QuickSortMiddleElement(int[] array, int lo, int high)
        {
            if (lo >= high) return;

            var p = PartitionMiddleElement(array, lo, high);
            QuickSortMiddleElement(array, lo, p); //the pivot is included on left partition
            QuickSortMiddleElement(array, p + 1, high);
        }

        private static int PartitionMiddleElement(int[] array, int lo, int high)
        {
            var pivot = array[(high + lo) / 2];
            var i = lo - 1;
            var j = high + 1;

            while (true)
            {
                do { i++; } while (array[i] < pivot);
                do { j--; } while (array[j] > pivot);

                //The indices crossed
                if (i >= j) return j;

                Swap(array, i, j);
            }
        }

        private static void Swap(int[] data, int i, int j)
        {
            if (i == j) return;

            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}
