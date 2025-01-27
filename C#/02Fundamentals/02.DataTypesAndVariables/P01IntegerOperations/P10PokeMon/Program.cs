using System;

namespace P10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int used = int.Parse(Console.ReadLine());
            int exhaust = int.Parse(Console.ReadLine());

            double half = power * 0.5;
            int count = 0;

            while (power >= used)
            {
                power -= used;
                count++;
                if (power == half && exhaust > 0)
                {
                    power /= exhaust;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(count);
        }
    }
}
