using System;
using System.Collections.Generic;
using System.Linq;

namespace _06StrongNumber
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int temp = number;
            int factorialSum = 0;

            while (temp > 0)
            {
                int currNum = temp % 10;
                temp /= 10;
                int curFactNum = 1;
                for (int i = 1; i <= currNum; i++)
                {
                    curFactNum *= i;
                }
                factorialSum += curFactNum;
            }

            string result = factorialSum == number ? "yes" : "no";
            Console.WriteLine(result);
        }
    }
}
