using System;
using System.Collections.Generic;
using System.Linq;

namespace P04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) > numbers.Count || int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) > numbers.Count || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Shift" && command[1] == "left")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        int first = numbers[0];
                        //int last = numbers[numbers.Count];
                        //numbers.RemoveAt(numbers.Last());
                        numbers.RemoveAt(0);
                        numbers.Add(first);
                        //numbers.Insert(0,last);
                    }
                }
                else if (command[0] == "Shift" && command[1] == "right")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        int last = numbers.Last();
                        numbers.RemoveAt(numbers.Count-1);
                        numbers.Insert(0, last);
                    }
                }

                command = Console.ReadLine().Split();

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
