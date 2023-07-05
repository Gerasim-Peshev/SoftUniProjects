using System;

namespace P01Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{(decimal.Parse(Console.ReadLine())/1000):f2}");
        }
    }
}
