using System;
using System.Collections.Generic;
using System.Linq;

namespace PA03MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int count = 0;
            while (command[0] != "end")
            {
                int firstIndex = 0;
                int secondIndex = 0;

                if (int.Parse(command[0]) > int.Parse(command[1]))
                {
                    firstIndex = int.Parse(command[1]);
                    secondIndex = int.Parse(command[0]);
                }
                else
                {
                    firstIndex = int.Parse(command[0]);
                    secondIndex = int.Parse(command[1]);
                }

                if (numbers.Count == 0)
                {
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }

                count++;



                if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < numbers.Count && secondIndex < numbers.Count && firstIndex != secondIndex)
                {
                    if (numbers[firstIndex] == numbers[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {numbers[firstIndex]}!");
                        numbers.RemoveAt(secondIndex);
                        numbers.RemoveAt(firstIndex);
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                    
                }
                else
                {
                    numbers.Insert(numbers.Count / 2, $"-{count}a");
                    int index = numbers.IndexOf($"-{count}a");
                    numbers.Insert(index + 1, $"-{count}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                command = Console.ReadLine().Split().ToArray();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine($"You have won in {count} turns!");

            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}