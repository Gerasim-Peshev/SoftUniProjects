using System;
using System.Linq;

namespace P06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                 .ToArray();
                jagged[i] = new double[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    jagged[i][j] = line[j];
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                if (i != 0)
                {
                    if (jagged[i].Length == jagged[i - 1].Length)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] *= 2;
                        }

                        for (int j = 0; j < jagged[i - 1].Length; j++)
                        {
                            jagged[i - 1][j] *= 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] /= 2;
                        }

                        for (int j = 0; j < jagged[i - 1].Length; j++)
                        {
                            jagged[i - 1][j] /= 2;
                        }
                    }
                }
            }

            var cmd = Console.ReadLine();
            while (true)
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "End")
                {
                    for (int i = 0; i < jagged.Length; i++)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            Console.Write($"{jagged[i][j]} ");
                        }

                        Console.WriteLine();
                    }

                    return;
                }
                var rol1 = int.Parse(command[1]);
                var col1 = int.Parse(command[2]);
                var val = double.Parse(command[3]);

                if (rol1 > -1 && col1 > -1 && rol1 < jagged.Length && col1 < jagged[rol1].Length)
                {
                    switch (command[0])
                    {
                        case "Add":
                            jagged[rol1][col1] += val;
                            break;
                        case "Subtract":
                            jagged[rol1][col1] -= val;
                            break;
                    }
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
