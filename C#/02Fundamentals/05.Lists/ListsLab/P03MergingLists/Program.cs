using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> merged = new List<int>();

            int count = numbers1.Count > numbers2.Count ? numbers2.Count : numbers1.Count;
            for (int i = 0; i < count; i++)
            {
                merged.Add(numbers1[i]);
                merged.Add(numbers2[i]);
                numbers1.RemoveAt(i);
                numbers2.RemoveAt(i);
                count--;
                i--;

            }

            if (numbers1.Count == 0)
            {
                merged.AddRange(numbers2);
            }
            else if (numbers2.Count == 0)
            {
                merged.AddRange(numbers1);
            }

            Console.WriteLine(string.Join(" ", merged));
        }
    }
}