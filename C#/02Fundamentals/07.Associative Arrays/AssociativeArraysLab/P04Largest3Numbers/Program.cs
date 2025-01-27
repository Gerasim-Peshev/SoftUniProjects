using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace P04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToList()));
        }
    }
}
