using System;
using System.Linq;

namespace P07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join("\n",Console.ReadLine().Split().Where(x=>x.Length <= n).ToList()));
        }
    }
}
