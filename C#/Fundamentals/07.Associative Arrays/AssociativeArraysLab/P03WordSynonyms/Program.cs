using System;
using System.Collections.Generic;

namespace P03WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string Key = Console.ReadLine();
                string Value = Console.ReadLine();

                if (!words.ContainsKey(Key))
                {
                    words.Add(Key,new List<string>());
                    words[Key].Add(Value);
                }
                else
                {
                    words[Key].Add(Value);
                }
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ",word.Value)}");
            }
        }
    }
}
