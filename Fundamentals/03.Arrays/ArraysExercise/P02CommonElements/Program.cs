using System;
using System.Linq;

namespace P02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(" ").ToArray();
            string[] second = Console.ReadLine().Split(" ").ToArray();

            int n = first.Length > second.Length ? first.Length : second.Length;
            string[] end = new string[n];

            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if (second[i] == first[j])
                    {
                        end[i] = second[i];
                    }
                }
            }

            for (int y = 0; y < end.Length; y++)
            {
                if (end[y] != null)
                {
                    Console.Write(end[y] + " ");
                }
            }
            
        }
    }
}
