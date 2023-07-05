using System;
using System.Collections.Generic;
using System.Linq;

namespace P02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(nums);

            var cmd = Console.ReadLine();
            while (cmd.ToLower() != "end")
            {
                var command = cmd.Split();
                if (command[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    if (numbers.Count > 0 && numbers.Count - int.Parse(command[1]) > 0)
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
