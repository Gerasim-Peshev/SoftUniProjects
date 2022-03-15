using System;
using System.Collections.Generic;
using System.Linq;

namespace P08ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numsToCheck = Console.ReadLine().Split().Select(double.Parse).ToList();
            var nums = new List<double>();
            for (int i = 1; i <= n; i++)
            {
                nums.Add(i);
            }

            var checkedNums = nums.Where(x => numsToCheck.All(f => x % f == 0)).ToList();
            Console.WriteLine(string.Join(" ", checkedNums));
        }
    }
}
