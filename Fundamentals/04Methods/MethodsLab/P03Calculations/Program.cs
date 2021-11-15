using System;
using System.Runtime.InteropServices;

namespace P03Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            Calculate(command, num1, num2);
        }

        static void Calculate(string command, double num1, double num2)
        {
            switch (command)
            {
                case "add":
                    Console.WriteLine(num1 + num2);
                    break;
                case "multiply":
                    Console.WriteLine(num1*num2);
                    break;
                case "subtract":
                    Console.WriteLine(num1 - num2);
                    break;
                case "divide":
                    Console.WriteLine(num1 / num2);
                    break;
            }
        }
    }
}
