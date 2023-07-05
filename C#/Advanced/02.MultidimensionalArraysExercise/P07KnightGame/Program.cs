using System;
using System.Collections.Generic;
using System.Linq;

namespace P07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j].ToString();
                }
            }

            int knightToRemove = 0;

            while (true)
            {
                int countBeat = 0;
                int knightRol = 0;
                int knightCol = 0;

                for (int rol = 0; rol < matrix.GetLength(0); rol++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[rol, col] == "0")
                        {
                            continue;
                        }

                        int curentAttacks = 0;

                        //up left and right
                        if (isInside(matrix, rol - 2, col - 1) && matrix[rol - 2, col - 1] == "K")
                        {
                            curentAttacks++;
                        }

                        if (isInside(matrix, rol - 2, col + 1) && matrix[rol - 2, col + 1] == "K")
                        {
                            curentAttacks++;
                        }

                        //left up and down
                        if (isInside(matrix, rol - 1, col - 2) && matrix[rol - 1, col - 2] == "K")
                        {
                            curentAttacks++;
                        }

                        if (isInside(matrix, rol - 1, col + 2) && matrix[rol - 1, col + 2] == "K")
                        {
                            curentAttacks++;
                        }

                        //down left and right
                        if (isInside(matrix, rol + 2, col + 1) && matrix[rol + 2, col + 1] == "K")
                        {
                            curentAttacks++;
                        }

                        if (isInside(matrix, rol + 2, col - 1) && matrix[rol + 2, col - 1] == "K")
                        {
                            curentAttacks++;
                        }
                        //right up and down
                        if (isInside(matrix, rol - 1, col + 2) && matrix[rol - 1, col + 2] == "K")
                        {
                            curentAttacks++;
                        }

                        if (isInside(matrix, rol + 1, col + 2) && matrix[rol + 1, col + 2] == "K")
                        {
                            curentAttacks++;
                        }

                        if (curentAttacks > countBeat)
                        {
                            countBeat = curentAttacks;
                            knightRol = rol;
                            knightCol = col;
                        }

                    }
                }

                if (countBeat > 0)
                {
                    knightToRemove++;
                    matrix[knightRol, knightCol] = "0";
                }
                else
                {
                    Console.WriteLine(knightToRemove);
                    break;
                }
            }
        }

        public static bool isInside(string[,] matrx, int rol, int col)
        {
            return rol > -1 && col > -1 && rol < matrx.GetLength(0) && col < matrx.GetLength(1) ? true : false;
        }
    }
}
