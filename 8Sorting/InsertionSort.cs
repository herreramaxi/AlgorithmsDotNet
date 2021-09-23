using System;

namespace _8Sorting
{
    public class InsertionSort
    {
        /// <summary>
        /// Time complexity: Best O(n), Average and worst O(n^2)<br></br>
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="array"></param>
        public static void SortSimple(int[] array)
        {   
            //O(n)
            for (int i = 1; i < array.Length; i++)
            {
                var keyElement = array[i];
                int pos = i;

                //O(n)
                while (pos > 0 && array[pos - 1] > keyElement)
                {
                    array[pos] = array[pos - 1];
                    pos--;
                }

                array[pos] = keyElement;
            }
        }

        /// <summary>
        /// Time complexity: O(n^2)<br></br>
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
        {
            //O(n)
            for (int which = 1; which < array.Length; which++)
            {
                var val = array[which];

                //O(n)
                for (int i = 0; i < which; i++)
                {
                    if (array[i] > val)
                    {
                        Array.Copy(array, i, array, i + 1, which - i);
                        array[i] = val;
                        break;
                    }
                }
            }
        }
    }
}
