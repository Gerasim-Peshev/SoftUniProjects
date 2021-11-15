using System;
using System.Diagnostics.CodeAnalysis;

namespace P07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            
            Repeat(word, repeat);
        }

        static void Repeat(string word, int repeat)
        {
            string sum = "";
            for (int i = 0; i < repeat; i++)
            {
                sum += word;
            }

            Console.WriteLine(sum);
        }
    }
}
