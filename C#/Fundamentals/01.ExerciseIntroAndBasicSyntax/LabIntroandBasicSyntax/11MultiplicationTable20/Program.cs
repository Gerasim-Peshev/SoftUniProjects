using System;

namespace _11MultiplicationTable20
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            if (second > 10)
            {
                Console.WriteLine($"{first} X {second} = {first*second}");
            }
            else if (second > 0 && second <= 10)
            {
                for (int i = second; i <= 10; i++)
                {
                    Console.WriteLine($"{first} X {i} = {first*i}");
                }
            }
        }
    }
}
