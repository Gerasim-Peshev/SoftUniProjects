using System;
using System.Linq;

namespace P01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = cmd[j];
                }
            }

            var firstSum = 0;
            var secondSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstSum += matrix[i, i];
            }

            int first = 0;
            int second = matrix.GetLength(0) - 1;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                secondSum += matrix[first, second];
                first++;
                second--;
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
