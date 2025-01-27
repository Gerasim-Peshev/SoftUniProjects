using System;
using System.Linq;

namespace P06EvenАndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Console.WriteLine($"{(numbers.Where(x => x % 2 == 0).Sum()) - (numbers.Where(x => x % 2 != 0).Sum())}");
        }
    }
}
