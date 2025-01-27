using System;

namespace P06CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(RectangleArea(weight, height));
            
        }

        static double RectangleArea(double weight, double height)
        {
            return weight * height;
        }
    }
}
