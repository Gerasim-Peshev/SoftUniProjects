using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace P08CondenseArrayToNumber
{
    class Program
    {


        // Doesn't work




        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> temp = new List<int>(numbers.Count);

            for (int y = 0; y < numbers.Count; y++)
            {
                temp.Add(0);
            }

            while (numbers.Count != 1)
            {
                for (int i = 0; i <= numbers.Count; i++)
                {
                    if (i != numbers.Count - 1)
                    {
                        temp[i] = numbers[i] + numbers[i + 1];
                    }
                    else
                    {
                        break;
                    }
                }

                
                numbers = temp;
                temp = new List<int>();
                for (int y = 0; y < numbers.Count; y++)
                {
                    temp.Add(0);
                }
            }

            Console.WriteLine(string.Join("", numbers));
        }
    }
}
