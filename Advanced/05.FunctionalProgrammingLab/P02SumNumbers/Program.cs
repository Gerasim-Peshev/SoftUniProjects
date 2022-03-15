using System;
using System.Linq;

namespace P02SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            var nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToList();
            Console.WriteLine($"{nums.Count}"+"\n"+$"{nums.Sum()}");
        }
    }
}
