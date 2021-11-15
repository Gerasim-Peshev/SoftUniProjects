using System;

namespace P08BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string name = string.Empty;
            double v2 = 0;

            for (int i = 0; i < n; i++)
            {
                string hold = string.Empty;
                double r = 0;
                double h = 0;
                double v1 = 0;

                hold = Console.ReadLine();
                r = double.Parse(Console.ReadLine());
                h = double.Parse(Console.ReadLine());
                v1 = (Math.PI * (r*r) * h);
                if (v1 > v2)
                {
                    name = hold;
                    v2 = v1;
                }

            }

            Console.WriteLine(name);
        }
    }
}
