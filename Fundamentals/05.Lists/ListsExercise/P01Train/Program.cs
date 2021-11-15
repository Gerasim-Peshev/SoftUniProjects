using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maximum = int.Parse(Console.ReadLine());

            var commands = Console.ReadLine().Split().ToArray();

            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    wagons.Add(int.Parse(commands[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(commands[0]) <= maximum)
                        {
                            wagons[i] += int.Parse(commands[0]);
                            break;
                        }
                    }
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
