using System;
using System.Linq;

namespace P04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parserToDouble = x => double.Parse(x);
            Func<double, double> VATcalc = x => Math.Round(x += x * 0.2, 2);

            Console.WriteLine($"{string.Join("\n", Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parserToDouble).Select(VATcalc).ToList())}");
        }
    }
}
