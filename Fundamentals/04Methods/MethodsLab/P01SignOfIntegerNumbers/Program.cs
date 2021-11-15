using System;

namespace P01SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PositiveOrNegative(num);
        }

        static void PositiveOrNegative(int num)
        {
            if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else if (num == 0)
            {
                Console.WriteLine($"The number {num} is zero.");
            }
        }
    }
}
