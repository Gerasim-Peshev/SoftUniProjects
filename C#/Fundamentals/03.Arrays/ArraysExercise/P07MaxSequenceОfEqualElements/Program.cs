using System;
using System.Linq;

namespace P07MaxSequenceОfEqualElements
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int num = 0;
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int start = numbers[i];
                int copycount = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] == start)
                    {
                        copycount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (copycount > count)
                {
                    num = start;
                    count = copycount;
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(num + " ");
            }
        }
    }
}
