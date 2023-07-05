using System;

namespace P08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{Power(num1) / Power(num2):f2}");
        }

        static double Power(int num)
        {
            double n = 1;
            while (num != 1)
            {
                n *= num;
                num--;
            }
            return n;
        }
    }
}
