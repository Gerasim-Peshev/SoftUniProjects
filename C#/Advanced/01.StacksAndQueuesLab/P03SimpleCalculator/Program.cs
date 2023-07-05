using System;
using System.Collections.Generic;

namespace P03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Stack<string> signs1 = new Stack<string>();
            Stack<string> signs2 = new Stack<string>();

            foreach (var c in input)
            {
                signs1.Push(c);
            }

            foreach (var s in signs1)
            {
                signs2.Push(s);
            }

            var sum = int.Parse(signs2.Pop().ToString());
            while (signs2.Count != 0)
            {
                var sign = signs2.Pop();

                if (sign == "+")
                {
                    sum += int.Parse(signs2.Pop());
                }
                else if (sign == "-")
                {
                    sum -= int.Parse(signs2.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
