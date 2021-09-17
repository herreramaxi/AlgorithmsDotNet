namespace SortAlgorithms
{
    /// <summary>
    ///<b>QuickSort</b><br></br>
    ///Class Sorting algorithm<br></br>
    ///<b>Worst-case performance</b> O(n^2)<br></br>
    ///<b>Best-case performance</b>	O(nlog n) (simple partition) or O(n) (three-way partition and equal keys)<br></br>
    ///<b>Average performance</b> O(nlog n)<br></br>
    ///<b>Worst-case space complexity</b> O(n) auxiliary (naive) O(log n) auxiliary (Hoare 1962)<br></br>
    ///<see href="https://en.wikipedia.org/wiki/Quicksort">QuickSort - Wiki</see>
    /// </summary>
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            QuickSortMiddleElementPivot(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Hoare partition scheme
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void QuickSortMiddleElementPivot(int[] array, int start, int end)
        {
            int pivotIndex;
            if (start >= end) return;

            pivotIndex = PartitionMiddleElementPivot(array, start, end);

            QuickSortMiddleElementPivot(array, start, pivotIndex - 1);
            QuickSortMiddleElementPivot(array, pivotIndex + 1, end);
        }

        //Hoare partition scheme
        private static int PartitionMiddleElementPivot(int[] array, int start, int end)
        {
            int down = end;
            int mid = (start + end) / 2;

            Swap(array, start, mid);

            var pivot = array[start];
            int up = start;

            while (up < down)
            {
                up++;

                while (up < end && array[up] < pivot)
                {
                    up++;
                }

                while (down > start && array[down] >= pivot)
                {
                    down--;
                }
                if (up < down)
                {
                    Swap(array, down, up);
                }
            }

            Swap(array, start, down);

            return down;
        }

        /// <summary>
        /// Lomuto partition scheme
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QuickSortLastElementPivot(int[] array,int start, int end)
        {
            int pivotIndex;
            if (start < end)
            {
                pivotIndex = partitionLomutoLastElementPivot(array, start, end);
                QuickSortLastElementPivot(array,start, pivotIndex - 1);
                QuickSortLastElementPivot(array,pivotIndex + 1, end);
            }
        }

        //Lomuto partition scheme
        public static int partitionLomutoLastElementPivot(int[] array, int low, int high)
        {
            var pivot = array[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    //swap the elements           
                    Swap(array, i, j);
                }
            }

            Swap(array,i + 1, high);

            return i + 1;
        }


        private static void Swap(int[] array, int position1, int position2)
        {
            var temp = array[position2];
            array[position2] = array[position1];
            array[position1] = temp;
        }
    }
}
