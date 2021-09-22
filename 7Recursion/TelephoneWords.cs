using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7Recursion
{
    public class TelephoneWords
    {
        private const int PHONE_NUMBER_LENGTH = 7;
        private readonly int[] _phoneNumber;
        private readonly string _charArray;
        private readonly char[] _result = new char[PHONE_NUMBER_LENGTH];

        public TelephoneWords(int[] n)
        {
            _phoneNumber = n;
            _charArray = "ABCDEFGHIJKLMNOPRSTUVWXY";
        }

        /// <summary>
        /// O(3^n)
        /// </summary>
        public void PrintWords()
        {
            PrintWords(0);
        }

        private void PrintWords(int curDigit)
        {
            if (curDigit == PHONE_NUMBER_LENGTH)
            {
                Console.WriteLine(new string(_result));
                return;
            }

            for (int i = 1; i <= 3; i++)
            {
                _result[curDigit] = GetCharKey(_phoneNumber[curDigit], i);
                PrintWords(curDigit + 1);

                if (_phoneNumber[curDigit] <= 1) return;
            }
        }
        private char GetCharKey(int telephoneKey, int place)
        {
            if (telephoneKey == 0) return '0';
            if (telephoneKey == 1) return '1';

            var index = (telephoneKey - 2) * 3 + (place - 1);
            return _charArray[index];
        }
    }
}
