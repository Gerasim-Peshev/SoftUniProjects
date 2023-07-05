using System;
using System.Collections.Generic;
using System.Text;

namespace P03Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            List<char> word = new List<char>();
            for (int i = 0; i < second.Length; i++)
            {
                word.Add(second[i]);
            }

            List<char> bannedChars = new List<char>();
            for (int i = 0; i < first.Length; i++)
            {
                bannedChars.Add(first[i]);
            }

            string result = "";

            while (second.IndexOf(first) >= 0)
            {
                second = second.Remove(second.IndexOf(first), first.Length);
            }
            
            Console.WriteLine(second);
        }
    }
}
