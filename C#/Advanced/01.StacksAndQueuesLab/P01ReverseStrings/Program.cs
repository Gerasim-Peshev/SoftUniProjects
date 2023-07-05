using System;
using System.Collections.Generic;

namespace P01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Stack<char> reversed = new Stack<char>();

            foreach (var c in input)
            {
                reversed.Push(c);
            }

            Console.WriteLine(string.Join("", reversed));
        }
    }
}
