using System;
using System.Collections.Generic;
using System.Linq;

namespace P03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicals = new SortedSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < cmd.Length; j++)
                {
                    chemicals.Add(cmd[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
