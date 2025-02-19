﻿using System;

namespace P02SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = 0;

            while (num != 0)
            {
                int piece = num % 10;
                sum += piece;
                num /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
