using System;
using System.Collections.Generic;
using System.Linq;

namespace P07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine().Split().ToArray();

            var numbers2 = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers2.Add(numbers[i]);
            }

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                else if (command[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEvenNumbers(numbers);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOddNumbers(numbers);
                }
                else if (command[0] == "GetSum")
                {
                    PrintSum(numbers);
                }
                else if (command[0] == "Filter")
                {
                    Filter(numbers, command[1], command[2]);
                }

                command = Console.ReadLine().Split().ToArray();
            }

            bool check = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != numbers2[i])
                {
                    check = false;
                    break;
                }
            }

            if (check == false)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

            //Console.WriteLine(string.Join(" ", numbers));
        }

        static void PrintEvenNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOddNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }

        static void PrintSum(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }

        static void Filter(List<int> numbers, string sign, string num)
        {
            if (sign == "<")
            {
                foreach (var number in numbers)
                {
                    if (number < int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            else if (sign == ">")
            {
                foreach (var number in numbers)
                {
                    if (number > int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            else if (sign == ">=")
            {
                foreach (var number in numbers)
                {
                    if (number >= int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            else if (sign == "<=")
            {
                foreach (var number in numbers)
                {
                    if (number <= int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            else if (sign == "==")
            {
                foreach (var number in numbers)
                {
                    if (number == int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            else if (sign == "!=")
            {
                foreach (var number in numbers)
                {
                    if (number != int.Parse(num))
                    {
                        Console.Write($"{number} ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
