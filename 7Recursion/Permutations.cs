using System;
using System.Text;

namespace _7Recursion
{
    public class Permutations
    {
        private string _in;
        private bool[] _used;
        private StringBuilder _out = new StringBuilder();

        public Permutations(string input)
        {
            _in = input;
            _used = new bool[input.Length];
        }

        public void Permute()
        {
            if (_out.Length == _in.Length)
            {
                Console.WriteLine(_out.ToString());
                return;
            }

            for (int i = 0; i < _in.Length; i++)
            {
                if (_used[i]) continue;

                _out.Append(_in[i]);
                _used[i] = true;
                Permute();
                _used[i] = false;
                _out.Length -= 1;
            }
        }

        /// <summary>
        /// O(n*n!)
        /// </summary>
        /// <param name="input"></param>
        public static void Permute2(string input)
        {
            Permute2(input, 0, input.Length - 1);
        }

        public static void Permute3(string input)
        {
            Permute3(input,"");
        }

        private static void Permute3(string s, string answer)
        {
            if (s.Length == 0) {
                Console.WriteLine(answer);
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                var leftSubstring = s.Substring(0, i);
                var rightSubstring = s.Substring(i+1);
                var rest = leftSubstring + rightSubstring;
                Permute3(rest, answer + ch);
            }
        }

        private static void Permute2(string input, int l, int r)
        {
            if (l == r)
            {
                Console.WriteLine(input);
                return;
            }

            for (int i = l; i <=r; i++)
            {
                input = Swap(input, l, i);
                Permute2(input, l + 1, r);                
                input = Swap(input, i, l);
            }
        }

        private static string Swap(string input, int i, int j)
        {
            var array = input.ToCharArray();
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            return new string(array);
        }
    }
}
