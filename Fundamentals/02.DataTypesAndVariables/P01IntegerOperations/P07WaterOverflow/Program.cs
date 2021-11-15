using System;

namespace P07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int tank = 255;

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int lt = int.Parse(Console.ReadLine());

                if (sum + lt > tank)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += lt;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
