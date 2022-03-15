using System;
using System.Linq;

namespace P04MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimenrtions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[dimenrtions[0], dimenrtions[1]];

            for (int i = 0; i < dimenrtions[0]; i++)
            {
                var line = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < dimenrtions[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            var cmd = Console.ReadLine();
            while (cmd != "END")
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "swap" && command.Length == 5)
                {
                    int rol1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int rol2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                    if (rol1 < matrix.GetLength(0) && rol2 < matrix.GetLength(0) && col1 < matrix.GetLength(1) && col2 < matrix.GetLength(1) && rol1 > -1 && rol2 > -1 && col1 > -1 && col2 > -1)
                    {
                        int first = matrix[rol1, col1];
                        int second = matrix[rol2, col2];

                        matrix[rol1, col1] = second;
                        matrix[rol2, col2] = first;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
