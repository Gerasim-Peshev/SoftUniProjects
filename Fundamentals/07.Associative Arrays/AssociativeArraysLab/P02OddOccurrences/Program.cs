using System;
using System.Collections.Generic;
using System.Linq;

namespace P02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().ToLower().Split().ToArray();

            Dictionary<string, int> parts = new Dictionary<string, int>();

            foreach (string cmd in command)
            {
                if (parts.ContainsKey(cmd))
                {
                    parts[cmd]++;
                }
                else
                {
                    parts.Add(cmd, 1);
                }
            }

            List<string> words = new List<string>();
            foreach (KeyValuePair<string, int> part in parts)
            {
                if (part.Value % 2 != 0)
                {
                    words.Add(part.Key);
                }
            }

            Console.WriteLine(string.Join(" ", words));
            
        }
    }
}
