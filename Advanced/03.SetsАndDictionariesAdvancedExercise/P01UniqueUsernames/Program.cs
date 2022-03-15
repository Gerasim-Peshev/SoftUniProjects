using System;
using System.Collections.Generic;

namespace P01UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n",usernames));
        }
    }
}
