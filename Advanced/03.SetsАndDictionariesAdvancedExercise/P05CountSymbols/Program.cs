using System;
using System.Collections.Generic;

namespace P05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!symbols.ContainsKey(word[i]))
                {
                    symbols.Add(word[i], 1);
                }
                else
                {
                    symbols[word[i]]++;
                }
            }

            foreach (var keyValuePair in symbols)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value} time/s");
            }
        }
    }
}
