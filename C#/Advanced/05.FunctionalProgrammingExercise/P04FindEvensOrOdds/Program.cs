using System;
using System.Collections.Generic;
using System.Linq;

namespace P04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parserInt = x => int.Parse(x);
            var range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(parserInt).ToList();
            var oddOrEven = Console.ReadLine();

            var nums = new List<int>();

            Func<int, bool> checker = GetEvenOrOdd(oddOrEven);
            for (int i = range[0]; i <= range[1]; i++)
            {
                if (checker(i))
                {
                    nums.Add(i);
                }
            }

            Action<int> printer = n => Console.Write($"{n} ");
            nums.ForEach(printer);
        }

        private static Func<int, bool> GetEvenOrOdd(string oddOrEven)
        {
            switch (oddOrEven)
            {
                case "even":
                    return n => n % 2 == 0;
                case "odd":
                    return n => n % 2 != 0;
                default:
                    return null;
            }
        }
    }
}
