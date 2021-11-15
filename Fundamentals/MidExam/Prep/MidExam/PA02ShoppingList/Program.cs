using System;
using System.Collections.Generic;
using System.Linq;

namespace PA02ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = Console.ReadLine().Split().ToArray();

            while (command[0] != "Go" && command[1] != "Shopping!")
            {
                if (command[0] == "Urgent" && !products.Contains(command[1]))
                {
                    products.Insert(0, command[1]);
                }
                else if (command[0] == "Unnecessary")
                {
                    products.Remove(command[1]);
                }
                else if (command[0] == "Correct" && products.Contains(command[1]))
                {
                    int oldProductIndex = products.IndexOf(command[1]);
                    products.RemoveAt(oldProductIndex);
                    products.Insert(oldProductIndex, command[2]);
                }
                else if (command[0] == "Rearrange" && products.Contains(command[1]))
                {
                    int indexOfItem = products.IndexOf(command[1]);
                    string item = products[indexOfItem];
                    products.RemoveAt(indexOfItem);
                    products.Add(item);
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", products));
        }
    }
}
