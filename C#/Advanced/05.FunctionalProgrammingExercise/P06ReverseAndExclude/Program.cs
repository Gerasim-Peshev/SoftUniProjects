
using System;
using System.Linq;

namespace P06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var num = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", nums.Where(x => x % num != 0).Reverse().ToList()));

        }
    }
}
