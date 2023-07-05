using System;
using System.Linq;

namespace P05WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", Console.ReadLine().Split().Where(word => word.Length % 2 == 0).ToList()));

            //GeriJorova
            //geriJorova

        }
    }
}
