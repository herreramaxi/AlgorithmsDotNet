namespace SortAlgorithms
{
    /// <summary>
    ///Class	Sorting algorithm<br></br>
    ///Data structure	Array<br></br>
    ///<b>Worst-case performance</b>	О(n2) comparisons and swaps<br></br>
    ///<b>Best-case performance</b>	O(n) comparisons, O(1) swaps<br></br>
    ///<b>Average performance</b>	О(n2) comparisons and swaps<br></br>
    ///<b>Worst-case space complexity</b>	О(n) total, O(1) auxiliary
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        ///An insertion sort algorithm divides the collection (array) into two regions
        ///After ith iteration, the array is partially sorted
        ///positions 0 through i  contain elements sorted in ascending order.
        ///postions i+1 through n-1 contain unsorted elements
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var keyElement = array[i];
                int pos = i;

                while (pos > 0 && array[pos - 1] > keyElement)
                {
                    var elementPosMinusOne = array[pos - 1];
                    array[pos] = elementPosMinusOne;

                    pos--;
                }

                array[pos] = keyElement;
            }
        }
    }
}
