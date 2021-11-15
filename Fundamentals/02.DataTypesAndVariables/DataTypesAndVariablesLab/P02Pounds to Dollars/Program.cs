using System;

namespace P02Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{(decimal)(double.Parse(Console.ReadLine())*1.31):f3}");
        }
    }
}
