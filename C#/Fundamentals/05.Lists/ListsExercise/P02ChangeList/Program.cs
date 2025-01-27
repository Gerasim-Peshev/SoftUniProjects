using System;
using System.Collections.Generic;
using System.Linq;

namespace P02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                else if (command[0] == "Delete")
                {
                    int num = int.Parse(command[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == num)
                        {
                            numbers.RemoveAt(i);
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
