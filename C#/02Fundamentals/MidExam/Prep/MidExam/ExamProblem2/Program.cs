using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ExamProblem2
{
    class Program
    {
        static void Main(string[] args)
        {

            //90/100 

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "Finish")
            {
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                }
                else if (command[0] == "Replace")
                {
                    int value = int.Parse(command[1]);
                    int replacement = int.Parse(command[2]);

                    //if (numbers.Contains(value))
                    //{
                        int indexOfValue = numbers.IndexOf(value);

                        numbers.RemoveAt(indexOfValue);

                        numbers.Insert(indexOfValue, replacement);
                    //}
                }
                else if (command[0] == "Collapse")
                {
                    numbers = numbers.Where(x => x >= int.Parse(command[1])).ToList();
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
