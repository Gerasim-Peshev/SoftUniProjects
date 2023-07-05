using System;
using System.Collections.Generic;
using System.Linq;


namespace P03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var nums = new Stack<double>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split().Select(double.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        nums.Push(command[1]);
                        break;
                    case 2:
                        if (nums.Count > 0)
                        {
                            nums.Pop();
                        }
                        break;
                    case 3:
                        if (nums.Count > 0)
                        {
                            Console.WriteLine(nums.Max());
                        }
                        break;
                    case 4:
                        if (nums.Count > 0)
                        {
                            Console.WriteLine(nums.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
