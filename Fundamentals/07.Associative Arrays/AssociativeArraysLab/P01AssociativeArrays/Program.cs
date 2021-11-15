using System;
using System.Collections.Generic;
using System.Linq;

namespace P01AssociativeArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> nums = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (double number in numbers)
            {
                if (nums.ContainsKey(number))
                {
                    nums[number]++;
                }
                else
                {
                    nums.Add(number, 1);
                }
            }

            
            foreach (KeyValuePair<double, int> num in nums)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
