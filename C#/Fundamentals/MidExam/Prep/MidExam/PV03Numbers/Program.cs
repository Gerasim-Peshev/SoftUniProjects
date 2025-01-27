using System;
using System.Collections.Generic;
using System.Linq;

namespace PV03Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //100/100
            List<int> sequenceIntegers = Console
                                        .ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();

            var result = sequenceIntegers.Where(x => x > sequenceIntegers.Average()).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine(string.Join(" ", result.OrderByDescending(x => x).Take(Math.Min(5, result.Count))));

            //90/100

            //List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            //numbers = numbers.Where(x => x > (numbers.Average())).OrderByDescending(x => x).ToList();



            //if (numbers.Count >= 5 && numbers.Count > 1)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.Write(numbers[i] + " ");
            //    }
            //}
            //else if (numbers.Count > 1 && numbers.Count < 5)
            //{
            //    Console.WriteLine(string.Join(" ", numbers));
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}
        }
    }
}
