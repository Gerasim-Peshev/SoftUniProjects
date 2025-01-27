using System;
using System.Collections.Generic;
using System.Linq;

namespace P06EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            List<int> indexes = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int firstSum = 0;
                int secondSum = 0;

                for (int j = 0; j < i; j++)
                {
                    firstSum += numbers[j];
                }

                for (int y = i + 1; y < numbers.Length; y++)
                {
                    secondSum += numbers[y];
                }

                if (firstSum == secondSum)
                {
                    indexes.Add(i);
                }
            }

            
            if (indexes.Count != 0)
            {
                Console.WriteLine(string.Join(" ", indexes));
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
