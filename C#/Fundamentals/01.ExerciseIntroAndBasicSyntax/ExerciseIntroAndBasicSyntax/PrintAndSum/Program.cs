using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int secont = int.Parse(Console.ReadLine());

            int num = first;
            int sum = 0;

            for (int i = first; i <= secont; i++)
            {
                sum += num;
                Console.Write($"{num} ");
                num++;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
