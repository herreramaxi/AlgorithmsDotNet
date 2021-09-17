namespace SortAlgorithms
{
    /// <summary>
    ///Class	Sorting algorithm<br></br>
    ///Data structure	Array<br></br>
    ///<b>Worst-case performance</b>	O(n^2) comparisons and swaps<br></br>
    ///<b>Best-case performance</b>	O(n) comparisons, O(1) swaps<br></br>
    ///<b>Average performance</b>	O(n^2) comparisons, O(n^2) swaps<br></br>
    ///<b>Worst-case space complexity</b>	 O(n) total, O(1) auxiliary
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// Bubble sort, sometimes referred to as sinking sort, is a simple sorting algorithm that repeatedly steps through the list,
        /// compares adjacent elements and swaps them if they are in the wrong order. 
        /// The pass through the list is repeated until the list is sorted. The algorithm, which is a comparison sort, 
        /// is named for the way smaller or larger elements "bubble" to the top of the list.       
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[j];
            array[j] = array[i];
            array[i] = array[temp];
        }
    }
}
