using System;

namespace P09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int spices = int.Parse(Console.ReadLine());

            int totalConsume = 0;
            int days = 0;
            while (spices >= 100)
            {
                totalConsume += spices - 26;
                spices -= 10;
                days++;
                if (spices < 100)
                {
                    totalConsume -= 26;
                }
            }

            Console.WriteLine(days);
            Console.WriteLine(totalConsume);
        }
    }
}
