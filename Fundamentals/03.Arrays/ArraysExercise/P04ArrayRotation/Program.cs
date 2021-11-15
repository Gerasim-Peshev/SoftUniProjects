using System;
using System.Linq;

namespace P04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotator = int.Parse(Console.ReadLine());

            int[] rotated = new int[rotator];
            int[] end = new int[numbers.Length];

            if (rotator > numbers.Length)
            {
                rotator -= numbers.Length;
            }

            for (int i = 0; i < rotator; i++)
            {
                rotated[i] = numbers[i];
            }

            for (int y = rotator; y < numbers.Length; y++)
            {

                end[y] = numbers[y];

            }


            for (int t = 0; t < end.Length; t++)
            {
                if (end[t] != 0)
                {
                    Console.Write(end[t] + " ");
                }
            }
            for (int u = 0; u < rotated.Length; u++)
            {
                if (rotated[u] != 0)
                {
                    Console.Write(rotated[u] + " ");
                }
            }
        }
    }
}
