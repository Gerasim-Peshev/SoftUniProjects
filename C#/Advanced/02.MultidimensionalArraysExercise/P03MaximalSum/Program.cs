using System;
using System.Linq;

namespace P03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dims = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[dims[0], dims[1]];

            for (int i = 0; i < dims[0]; i++)
            {
                var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < dims[1]; j++)
                {
                    matrix[i, j] = cmd[j];
                }
            }

            int sum = 0;
            int startRow = 0;
            int startCol = 0;
            for (int i = 0; i < dims[0]; i++)
            {
                for (int j = 0; j < dims[1]; j++)
                {
                    int curSum = 0;
                    if (i < dims[0] - 2 && j < dims[1] - 2 && i > -1 && j > -1)
                    {
                        curSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                 matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                 matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                        if (curSum > sum)
                        {
                            sum = curSum;
                            startRow = i;
                            startCol = j;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol + 1]} {matrix[startRow, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]} {matrix[startRow + 1, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 2, startCol]} {matrix[startRow + 2, startCol + 1]} {matrix[startRow + 2, startCol + 2]}");
        }
    }
}
