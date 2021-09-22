using System;
using System.Collections.Generic;

namespace _6ArraysAndStrings
{
    public class FirstNonRepeatedCharacter
    {
        /// <summary>
        /// Time complexity: O(N)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char? Get(string input)
        {
            var dictionary = new Dictionary<char, int>();

            //O(N)
            for (int i = 0; i < input.Length; i++)
            {
                var character = input[i];

                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 1;
                }
                else
                {
                    dictionary[character]++;
                }
            }

            //O(N)
            foreach (var character in input)
            {
                if (dictionary[character] == 1) return character;
            }

            return null;
        }
    }
}
