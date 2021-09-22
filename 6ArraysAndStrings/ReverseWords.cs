using System.Linq;
using System.Text;

namespace _6ArraysAndStrings
{
    public class ReverseWords
    {
        public static string Get(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            //O(N)
            var words = input.Split(" ");

            //O(N)
            return words.Aggregate((accum, word) => word + " " + accum);
        }

        public static string Get2(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            //O(N)
            var words = input.Split(" ");
            var sb = new StringBuilder();

            //O(N)
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);

                if (i > 0)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        public static string Get3(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var buffer = new char[input.Length];
            var processingWord = false;
            var startIndex = 0;
            var endIndex = 0;
            var j = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    if (processingWord)
                    {
                        processingWord = false;
                        startIndex = i + 1;

                        for (int k = startIndex; k <= endIndex; k++)
                        {
                            buffer[j++] = input[k];
                        }
                    }

                    buffer[j++] = input[i];
                }
                else
                {
                    if (!processingWord)
                    {
                        processingWord = true;
                        endIndex = i;
                    }
                }
            }

            if (processingWord)
            {
                startIndex = 0;

                for (int k = startIndex; k <= endIndex; k++)
                {
                    buffer[j++] = input[k];
                }
            }

            return new string(buffer);
        }

        public static string Get4(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var buffer = new char[input.Length];
            var readIndex = input.Length - 1;
            var writeIndex = 0;

            while (readIndex >= 0)
            {
                if (input[readIndex] == ' ')
                {
                    buffer[writeIndex++] = ' ';
                    readIndex--;
                }
                else
                {
                    var endIndex = readIndex;

                    while (readIndex >= 0 && input[readIndex] != ' ')
                        readIndex--;

                    var startIndex = readIndex + 1;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        buffer[writeIndex++] = input[i];
                    }
                }
            }

            return new string(buffer);
        }
    }
}
