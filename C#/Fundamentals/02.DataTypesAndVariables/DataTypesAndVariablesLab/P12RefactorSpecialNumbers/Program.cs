using System;

namespace P12RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            bool check = false;
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                num = i;
                while (num > 0)
                {
                    sum += num % 10;
                    num = num / 10;
                }
                check = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {check}");
            }

        }
    }
}
