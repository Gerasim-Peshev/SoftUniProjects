using System;
using System.Collections.Generic;
using System.Linq;

namespace P04ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            int count = 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{count}.{products[i]}");
                count++;
            }
        }
    }
}