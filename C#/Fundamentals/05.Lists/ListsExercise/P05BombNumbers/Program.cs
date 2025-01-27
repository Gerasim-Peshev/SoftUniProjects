using System;
using System.Collections.Generic;
using System.Linq;

namespace P05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bomb = Console.ReadLine().Split().Select(int.Parse).ToList();




            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb[0])
                {
                    int firstIndex = i - bomb[1];
                    int lastIndex = i + bomb[1];

                    if (lastIndex > numbers.Count)
                    {
                        lastIndex = numbers.Count - firstIndex+1;
                        for (int p = firstIndex; p <= lastIndex; p++)
                        {
                            numbers.RemoveAt(firstIndex);
                        }
                        //numbers.RemoveRange(firstIndex, lastIndex);
                    }
                    else if (firstIndex < 0)
                    {
                        for (int o = 0; o <= lastIndex; o++)
                        {
                            numbers.RemoveAt(0);
                        }
                        //numbers.RemoveRange(0, lastIndex);
                    }
                    else
                    {
                        for (int j = firstIndex; j <= lastIndex; j++)
                        {
                            numbers.RemoveAt(firstIndex);
                        }
                        //numbers.RemoveRange(firstIndex, lastIndex);
                    }

                    i = -1;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
