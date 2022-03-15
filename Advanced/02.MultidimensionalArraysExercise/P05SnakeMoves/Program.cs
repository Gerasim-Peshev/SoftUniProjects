using System;
using System.Linq;

namespace P05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            var word = Console.ReadLine();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (count == word.Length)
                        {
                            count = 0;
                        }

                        matrix[i, j] = word[count].ToString();
                        count++;
                    }
                }
                else if (i % 2 != 0)
                {
                    for (int j = matrix.GetLength(1)-1; j >= 0; j--)
                    {
                        if (count == word.Length)
                        {
                            count = 0;
                        }

                        matrix[i, j] = word[count].ToString();
                        count++;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
