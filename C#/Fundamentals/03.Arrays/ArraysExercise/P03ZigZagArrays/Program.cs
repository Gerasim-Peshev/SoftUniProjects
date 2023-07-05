using System;

namespace P03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] first = new int[n];
            int[] second = new int[n];

            for (int i = 0; i < n; i++)
            {
                string[] temp = Console.ReadLine().Split(" ");
                if (i % 2 == 0)
                {
                    first[i] = int.Parse(temp[1]);
                    second[i] = int.Parse(temp[0]);
                }
                else
                {
                first[i] = int.Parse(temp[0]);
                second[i] = int.Parse(temp[1]);
                }
            }

            Console.WriteLine(string.Join(" ",second));
            Console.WriteLine(string.Join(" ",first));
        }
    }
}
