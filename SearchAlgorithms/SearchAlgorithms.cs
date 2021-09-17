using System;

namespace SearchAlgorithms
{
    public class SearchAlgorithms
    {
        /// <summary>
        /// Worst complexity: O(n)
        /// Average complexity: O(n)
        /// Space complexity: O(1)
        /// Average performance: O(n/2)
        /// Class: Search algorithm
        /// </summary>
        /// <param name="array"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int LinearSearch(int[] array, int key)
        {
            int k = 0;

            while (k < array.Length && array[k] < key)
            {
                k++;
            }

            int result = k < array.Length && array[k] == key ? k : -1;

            return result;
        }

        /// <summary>
        /// Worst complexity: O(log n)
        /// Average complexity: O(log n)
        /// Best complexity: O(1)
        /// Space complexity: O(1)
        /// Data structure: Array
        /// Class: Search algorithm
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] list, int key)
        {
            var start = 0;
            var end = list.Length - 1;

            while (start <= end)
            {
                var middle = (end + start) / 2;
                var comparison = key - list[middle];

                if (comparison == 0)
                {
                    return middle;
                }

                if (comparison > 0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return -1;
        }
    }
}
