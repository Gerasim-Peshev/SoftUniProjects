using System;
using System.Linq;

namespace P03RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(" ").Select(decimal.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i],MidpointRounding.AwayFromZero)}");
            }

            
        }
    }
}
