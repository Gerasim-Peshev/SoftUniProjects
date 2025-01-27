using System;

namespace P08TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int pop = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {name} has population of {pop} and area {size} square km.");
        }
    }
}
