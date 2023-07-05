using System;
using System.Linq;

namespace P03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isStartWithUpper = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join("\n",Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(isStartWithUpper).ToList()));
        }
    }
}
