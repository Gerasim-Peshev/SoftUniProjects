using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> items = new Dictionary<string, List<double>>();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "buy")
            {
                string product = command[0];
                double price = double.Parse(command[1]);
                double quantity = double.Parse(command[2]);

                if (!items.ContainsKey(product))
                {
                    items.Add(product,new List<double>(){price,quantity});
                }
                else
                {
                    items[product][0] = price;
                    items[product][1] += quantity;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.ElementAt(0) * item.Value.ElementAt(1):f2}");
            }
        }
    }
}
