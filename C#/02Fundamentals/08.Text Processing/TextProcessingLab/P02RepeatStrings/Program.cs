using System;
using System.Linq;

namespace P02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            string line = "";
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    line += word;
                }
            }

            Console.WriteLine(line);
        }
    }
}
