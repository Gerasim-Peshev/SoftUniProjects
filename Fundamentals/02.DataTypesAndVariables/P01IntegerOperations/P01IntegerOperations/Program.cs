﻿using System;

namespace P01IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int forthNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"{((firstNum+secondNum)/thirdNum)*forthNum}");
        }
    }
}
