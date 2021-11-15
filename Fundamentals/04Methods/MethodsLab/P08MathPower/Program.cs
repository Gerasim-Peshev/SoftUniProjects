using System;
using System.Threading.Channels;

namespace P08MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(RaisePower(num, power));
        }

        static double RaisePower(double num, int power)
        {
            return Math.Pow(num, power);
        }
    }
}
