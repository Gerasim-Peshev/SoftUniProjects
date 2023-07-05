using System;
using System.Linq;

namespace P02PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] numbers = new string[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            numbers = numbers.Reverse().ToArray();

            

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
