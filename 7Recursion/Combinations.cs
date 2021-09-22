using System;
using System.Text;

namespace _7Recursion
{
    public class Combinations
    {
        private StringBuilder _output = new StringBuilder();
        private string _in;

        public Combinations( string  str )
        {
            _in = str;
        }

        public void Combine() {
            Combine(0);
        }

        private void Combine(int start)
        {
            for (int i = start; i < _in.Length; i++)
            {
                _output.Append(_in[i]);
                Console.WriteLine(_output.ToString());
                Combine(i + 1);
                _output.Length = _output.Length - 1;
            }
        }
    }
}
