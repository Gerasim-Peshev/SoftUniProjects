using System;
using  System.Collections.Generic;
using System.Linq;

namespace P06ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(" ").ToArray();

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
                else
                {
                    numbers.Insert(int.Parse(command[2]),int.Parse(command[1]));
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
