using System;
using System.Text;

namespace _6ArraysAndStrings
{
    public class StringToInt
    {
        //O(N)
        public static int Get(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            long output = 0;
            var sign = 1;

            for (int i = input.Length - 1, pow = 0; i >= 0; i--)
            {
                if (char.IsNumber(input[i]))
                {
                    output += Convert.ToInt32(input[i].ToString()) * (int)Math.Pow(10, pow++);
                }
                else if (input[i] == '-')
                    sign = -1;
            }

            return (int)(output * sign);
        }

        public static int Get1(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            long output = 0;
            var sign = 1;

            for (int i = input.Length - 1, pow = 0; i >= 0; i--)
            {
                if (char.IsNumber(input[i]))
                {
                    output += Convert.ToInt32(input[i].ToString()) * GetPower(10, pow++);
                }
                else if (input[i] == '-')
                    sign = -1;
            }

            return (int)(output * sign);
        }

        private static int GetPower(int number, int power)
        {
            if (power == 0) return 1;

            var output = number;

            for (int i = 0; i < power - 1; i++)
            {
                output *= number;
            }

            return output;
        }

        public static int Get2(string input)
        {
            return Convert.ToInt32(input);
        }

        public static int Get3(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var sign = 1;
            long output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    sign = -1;
                    continue;
                }

                output *= 10;
                output += (input[i] - '0');
            }

            return (int)(sign * output);
        }
    }
}
