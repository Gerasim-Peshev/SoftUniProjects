using System;
using System.Collections.Generic;

namespace P05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Queue<int> nums = new Queue<int>();
            Queue<int> evenNums = new Queue<int>();

            foreach (var c in input)
            {
                nums.Enqueue(int.Parse(c.ToString()));
            }


            while (nums.Count > 0)
            {
                var num = nums.Dequeue();
                if (num % 2 == 0)
                {
                    evenNums.Enqueue(num);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
