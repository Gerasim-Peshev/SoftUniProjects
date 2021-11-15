using System;
using System.Collections.Generic;
using System.Linq;

namespace P01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> words = new Dictionary<char, int>();

            List<string> command = Console.ReadLine().Split().ToList();

            for (int i = 0; i < command.Count; i++)
            {
                char[] chars = command[i].ToCharArray();
                for (int j = 0; j < chars.Length; j++)
                {
                    if (!words.ContainsKey(chars[j]))
                    {
                        words.Add(chars[j], 1);
                    }
                    else
                    {
                        words[chars[j]]++;
                    }
                }
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} -> {word.Value}");
            }
        }
    }
}
