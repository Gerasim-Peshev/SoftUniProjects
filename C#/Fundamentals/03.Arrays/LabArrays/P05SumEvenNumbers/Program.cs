using System;
using System.Linq;

namespace P05SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray().Where(x => x % 2 == 0).Sum();

            //double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            //double sum = 0;

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] % 2 == 0)
            //    {
            //        sum += numbers[i];
            //    }
            //}

            //Console.WriteLine(sum);

            Console.WriteLine(numbers);


        }
    }
}
