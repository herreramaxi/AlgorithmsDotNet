using System;

namespace _7Recursion
{
    public class FactorialR
    {
        public static int Factorial(int num)
        {
            if (num <= 1) return 1;

            return num * Factorial(num - 1);
        }

        public static int FactorialNonRecursive(int n)
        {
            int val = 1;
            for (int i = n; i >1; i--)
            {
                val *= i;
            }

            return val;
        }

        public static int[] AllFactorials(int num)
        {
            var results = new int[num == 0 ? 1 : num];
            DoAllFactorials(num, results, 0);

            return results;
        }

        private static int DoAllFactorials(int num, int[] results, int level)
        {
            if (num <= 1) {
                results[level] = 1;
                return 1;
            }

            results[level] = num * DoAllFactorials(num -1, results, level + 1);
            return results[level];
        }
    }
}
