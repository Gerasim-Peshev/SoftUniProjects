using System;
using System.Collections.Generic;
using System.Linq;

namespace PV02ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "swap")
                {
                    if (int.Parse(command[1]) > -1 && int.Parse(command[1]) < numbers.Count &&
                        int.Parse(command[2]) > -1 && int.Parse(command[2]) < numbers.Count)
                    {
                        int firstIndex = int.Parse(command[1]);
                        int secondIndex = int.Parse(command[2]);
                        int first = numbers[firstIndex];
                        int second = numbers[secondIndex];


                        numbers.RemoveAt(firstIndex);
                        numbers.Insert(firstIndex, second);

                        numbers.RemoveAt(secondIndex);
                        numbers.Insert(secondIndex, first);
                    }
                }
                else if (command[0] == "multiply")
                {
                    if (int.Parse(command[1]) > -1 && int.Parse(command[1]) < numbers.Count && int.Parse(command[2]) > -1 && int.Parse(command[2]) < numbers.Count)
                    {
                        int firstIndex = int.Parse(command[1]);
                        int secondIndex = int.Parse(command[2]);

                        numbers[firstIndex] *= numbers[secondIndex];
                    }
                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
