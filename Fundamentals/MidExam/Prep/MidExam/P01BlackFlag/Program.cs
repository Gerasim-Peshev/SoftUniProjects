using System;


namespace P01BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double dailyGain = double.Parse(Console.ReadLine());
            double target = double.Parse(Console.ReadLine());

            double sum = 0;
            
            for (int i = 1; i <= days; i++)
            {
                sum += dailyGain;

                if (i % 3 == 0)
                {
                    sum += dailyGain * 0.5;
                }
                if (i % 5 == 0)
                {
                    sum -= sum * 0.3;
                }

            }

            if (sum >= target)
            {
                Console.WriteLine($"Ahoy! {(decimal)(sum):f2} plunder gained.");
            }
            else
            {
                double num = sum / target * 100;
                Console.WriteLine($"Collected only {(decimal)(num):f2}% of the plunder.");
            }
        }
    }
}