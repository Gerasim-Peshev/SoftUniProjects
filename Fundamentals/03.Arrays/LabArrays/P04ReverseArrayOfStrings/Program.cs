using System;
using System.Linq;

namespace P04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var signs = Console.ReadLine().Split(" ").ToArray();

            signs = signs.Reverse().ToArray();
            Console.WriteLine(string.Join(" ",signs));
        }
    }
}
