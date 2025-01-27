using System;

namespace P11RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght, wide, hight = 0;
            Console.Write("Length: ");
            lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            wide = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            hight = double.Parse(Console.ReadLine());
            double sum = ((lenght * wide) * hight) / 3;
            Console.WriteLine($"Pyramid Volume: {sum:f2}");

        }
    }
}
