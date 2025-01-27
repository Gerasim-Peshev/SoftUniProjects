using System;

namespace P03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopele = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine((int)(Math.Ceiling((double)peopele / capacity)));

        }
    }
}
