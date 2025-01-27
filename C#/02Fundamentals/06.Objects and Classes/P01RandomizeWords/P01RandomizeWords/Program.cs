using System;
using System.Collections.Generic;
using System.Linq;

namespace P01RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Random random = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int swapPosotion = random.Next(words.Count);
                string temp = words[i];
                words[i] = words[swapPosotion];
                words[swapPosotion] = temp;
            }

            Console.WriteLine(string.Join("\n",words));
        }
    }
}
