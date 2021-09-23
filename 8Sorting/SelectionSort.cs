using System;

namespace _8Sorting
{
    public class SelectionSort
    {
        /// <summary>
        /// Time complexity: O(n^2)<br></br>
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="data"></param>
        public static void Sort(int[] data)
        {
            Sort(data, 0);
        }

        private static void Sort(int[] data, int start)
        {
            if (start >= data.Length - 1) return;

            Swap(data, start, GetMinimumIndex(data, start));
            Sort(data, start + 1);
        }

        /// <summary>
        /// Time complexity: O(n^2)<br></br>
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="data"></param>
        public static void SortNonRecursive(int[] data)
        {
            //O(N)
            for (int i = 0; i < data.Length - 1; i++)
            {
                //get minimum index O(N)
                var minIndex = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[j] < data[minIndex])
                        minIndex = j;
                }

                //swap element
                if (i == minIndex) continue;

                var temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }
        }

        private static int GetMinimumIndex(int[] data, int start)
        {
            var minPos = start;

            for (int i = start + 1; i < data.Length; i++)
            {
                if (data[i] < data[minPos])
                    minPos = i;
            }

            return minPos;
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
