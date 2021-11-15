using System;
using System.Linq;

namespace P07EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var second = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            int num = 0;
            bool check = false;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    check = false;
                    num = i;
                    break;
                }
                else
                {
                    check = true;
                }
            }

            if (check==true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {first.Sum()}");
            }
            else if (check==false)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {num} index");
            }
        }
    }
}
