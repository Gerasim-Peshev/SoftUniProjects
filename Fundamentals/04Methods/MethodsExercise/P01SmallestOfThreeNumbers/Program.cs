using System;

namespace P01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNum(num1, num2, num3));
            
        }

        static int SmallestNum(int num1, int num2, int num3)
        {
            //if (num1 < num2 && num1 < num3)
            //{
            //    return num1;
            //}
            //else if (num2 < num1 && num2 < num3)
            //{
            //    return num2;
            //}
            //else
            //{
            //    return num3;
            //}

            return Math.Min(num1, Math.Min(num2, num3));
        }
    }
}
