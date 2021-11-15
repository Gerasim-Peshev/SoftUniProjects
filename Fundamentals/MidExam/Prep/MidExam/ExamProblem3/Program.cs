using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamProblem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                       .ToList();

            int position = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            if (type == "cheap")
            {
                int firstSum = 0;
                int secondSum = 0;

                for (int i = 0; i < position; i++)
                {
                    if (numbers[i] < numbers[position])
                    {
                        firstSum += numbers[i];
                    }
                }

                for (int j = position + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] < numbers[position])
                    {
                        secondSum += numbers[j];
                    }
                }

                if (firstSum == secondSum)
                {
                    Console.WriteLine($"Left - {firstSum}");
                }
                else if (firstSum > secondSum)
                {
                    Console.WriteLine($"Left - {firstSum}");
                }
                else if (secondSum > firstSum)
                {

                    Console.WriteLine($"Right - {secondSum}");
                }
            }
            else if (type == "expensive")
            {
                int firstSum = 0;
                int secondSum = 0;

                for (int i = 0; i < position; i++)
                {
                    if (numbers[i] >= numbers[position])
                    {
                        firstSum += numbers[i];
                    }
                }

                for (int j = position + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] >= numbers[position])
                    {
                        secondSum += numbers[j];
                    }
                }

                if (firstSum == secondSum)
                {
                    Console.WriteLine($"Left - {firstSum}");
                }
                else if (firstSum > secondSum)
                {
                    Console.WriteLine($"Left - {firstSum}");
                }
                else if (secondSum > firstSum)
                {

                    Console.WriteLine($"Right - {secondSum}");
                }
            }
        }
    }
}
