using System;

namespace _09SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int y = 1;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(y);
                sum += y;
                y += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
