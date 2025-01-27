using System;

namespace P05SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());



            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int sum = 0;
                for (int y = i.ToString().Length; y >= 0; y--)
                {
                    sum += (num % 10);
                    num /= 10;
                }
                num = i;
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{num} -> True");
                }
                else
                {
                    Console.WriteLine($"{num} -> False");
                }
            }
        }
    }
}
