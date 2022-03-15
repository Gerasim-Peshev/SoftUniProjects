using System;
using System.Linq;

namespace P02SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var cmd = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = cmd[j];
                }
            }

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i < rows-1 && j < cols-1 && i > -1 && j > -1)
                    {
                        if (matrix[i,j] == matrix[i,j+1] && matrix[i, j] ==matrix[i+1,j] && matrix[i, j] == matrix[i+1,j+1])
                        {
                            count++;
                        }
                    }
                }
            }

            if (count > 1)
            {
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
