using System;
using System.Runtime.InteropServices;

namespace P05Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double quantity = int.Parse(Console.ReadLine());
            Order(type, quantity);
        }

        static void Order(string type, double quantity)
        {
            switch (type)
            {
                case "coffee":
                    Console.WriteLine($"{quantity*1.5:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{quantity*1.4:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{quantity*1:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{quantity*2:f2}");
                    break;
            }
        }
    }
}
