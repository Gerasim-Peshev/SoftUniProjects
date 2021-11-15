using System;
using System.Numerics;

namespace P02BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Calculate result = new Calculate();

            Console.WriteLine(result.Calculation(n));
        }

    }

    class Calculate
    {
        public BigInteger Calculation(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
