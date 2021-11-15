using System;
using System.Collections.Generic;
using System.Linq;

namespace P01SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == numbers.Count - 1)
                {
                    break;
                }
                else
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] += numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        i = -1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}