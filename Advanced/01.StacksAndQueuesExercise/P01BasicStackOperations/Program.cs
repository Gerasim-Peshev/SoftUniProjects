using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var operators = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

            var count = operators[0];
            var popCount = operators[1];
            var numToFind = operators[2];

            var number = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            var numbers = new Stack<int>();

            foreach (var i in number)
            {
                numbers.Push(i);
            }

            for (int i = 0; i < popCount; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numbers.Contains(numToFind))
                {
                    Console.WriteLine($"true");
                }
                else
                {
                    var smallestNum = int.MaxValue;
                    foreach (var i in numbers) if (i < smallestNum) smallestNum = i;

                    Console.WriteLine(smallestNum);
                }
            }
        }
    }
}