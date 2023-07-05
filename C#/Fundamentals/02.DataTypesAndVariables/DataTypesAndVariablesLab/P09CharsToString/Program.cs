using System;
using System.Collections.Generic;
using System.Linq;

namespace P09CharsToString
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

            Console.WriteLine($"{signs[0]}{signs[1]}{signs[2]}");
        }
    }
}
