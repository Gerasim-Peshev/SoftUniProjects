using System;
using System.Collections.Generic;

namespace P06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> buyers = new Queue<string>();

            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                if (cmd == "Paid" && buyers.Count > 0)
                {
                    while (buyers.Count != 0)
                    {
                        Console.WriteLine(buyers.Dequeue());
                    }
                }
                else
                {
                    buyers.Enqueue(cmd);
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{buyers.Count} people remaining.");
        }
    }
}
