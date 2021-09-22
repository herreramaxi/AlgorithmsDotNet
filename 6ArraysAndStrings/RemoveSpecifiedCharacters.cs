using System.Linq;
using System.Text;

namespace _6ArraysAndStrings
{
    public class RemoveSpecifiedCharacters
    {
        //O(N^2)      
        public static string RemoveChars(string input, string remove)
        {
            var sb = new StringBuilder();

            //O(N)
            for (int i = 0; i < input.Length; i++)
            {
                //O(N)
                if (!remove.Contains(input[i]))
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }

        //O(N)
        public static string RemoveCharsWithHash(string input, string remove)
        {
            //O(N)
            var hashset = remove.ToHashSet();
            var sb = new StringBuilder();

            //O(N)
            for (int i = 0; i < input.Length; i++)
            {
                //O(1)
                if (!hashset.Contains(input[i]))
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }

        public static string RemoveCharsWithArrays(string input, string remove)
        {
            var s = input.ToCharArray();
            var r = remove.ToCharArray();
            var flags = new bool[128];

            for (int i = 0; i < r.Length; i++)
            {
                flags[r[i]] = true;
            }

            var dst = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!flags[s[i]])
                {
                    s[dst++] = s[i];
                }
            }

            return new string(s, 0, dst);
        }
    }
}
