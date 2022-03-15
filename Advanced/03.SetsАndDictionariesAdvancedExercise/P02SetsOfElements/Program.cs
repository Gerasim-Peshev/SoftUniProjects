using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace P02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimesnsions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < dimesnsions[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < dimesnsions[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }


            var similarNums = new List<int>();

            foreach (var fur in first)
            {
                foreach (var sec in second)
                {
                    if (fur == sec)
                    {
                        similarNums.Add(fur);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", similarNums));
        }
    }
}
