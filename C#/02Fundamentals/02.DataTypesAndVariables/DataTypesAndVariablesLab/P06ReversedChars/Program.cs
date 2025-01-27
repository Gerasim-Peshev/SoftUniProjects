using System;
using System.Linq;
using System.Collections.Generic;

namespace P06ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> signs = new List<string>(3);

            for (int i = 0; i < 3; i++)
            {
                signs.Add(Console.ReadLine());
            }

            signs.Reverse();
            Console.WriteLine(string.Join(" ", signs));
        }
    }
}
