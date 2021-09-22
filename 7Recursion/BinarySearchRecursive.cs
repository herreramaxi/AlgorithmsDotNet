namespace _7Recursion
{
    public class BinarySearchRecursive
    {
        public static int BS(int[] array, int num)
        {
            return BS(array, num, 0, array.Length - 1);
        }

        private static int BS(int[] array, int num, int start, int end)
        {
            if (start > end) return -1;

            var middle = (start + end) / 2;
            if (array[middle] == num) return middle;

            if (num < array[middle])
            {
                return BS(array, num, start, middle - 1);
            }

            return BS(array, num, middle + 1, end);
        }
    }
}
