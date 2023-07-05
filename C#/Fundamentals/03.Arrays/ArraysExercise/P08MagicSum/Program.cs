using System;
using System.Collections.Generic;
using System.Linq;

namespace P08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            List<int> correct = new List<int>();

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                for (int j = i + 1; j <= numbers.Length - 1; j++)
                {

                    if (numbers[i] + numbers[j] == n)
                    {
                        correct.Add(numbers[i]);
                        correct.Add(numbers[j]);
                    }

                }
            }

            for (int i = 0; i < correct.Count; i += 2)
            {
                Console.WriteLine($"{correct[i]} {correct[i + 1]}");
            }
        }
    }
}
