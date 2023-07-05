using System;
using System.Collections.Generic;
using System.Linq;

namespace P07Concat_Names
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

            Console.WriteLine($"{signs[0]}{signs[2]}{signs[1]}");
        }
    }
}
