using System.Text;

namespace _6ArraysAndStrings
{
    public class IntToString
    {
        public static string Get(int number)
        {
            var buffer = new char[11];
            var bIndex = 0;
            var negative = false;
            long longNum = number;
            if (longNum < 0)
            {
                negative = true;
                longNum *= -1;
            }

            do
            {
                buffer[bIndex++] = (char)((longNum % 10) + '0');
                longNum /= 10;
            } while (longNum != 0);

            var sb = new StringBuilder();

            if (negative)
            {
                sb.Append("-");
            }

            for (int i = bIndex - 1; i >= 0; i--)
            {
                sb.Append(buffer[i]);
            }

            return sb.ToString();
        }
    }
}
