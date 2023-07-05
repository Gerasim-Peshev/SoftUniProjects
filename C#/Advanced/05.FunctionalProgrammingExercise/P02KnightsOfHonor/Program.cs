using System;
using System.Linq;
using System.Threading.Channels;

namespace P02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printSirs = name => Console.WriteLine($"Sir {name}");

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(printSirs);
        }
    }
}
