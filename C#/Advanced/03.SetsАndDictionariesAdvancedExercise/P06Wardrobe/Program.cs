using System;
using System.Collections.Generic;
using System.Linq;

namespace P06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] splitStrings = new string[] { " -> ", "," };

            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string,int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var color = line[0];
                var clothes = line[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color,new Dictionary<string, int>());
                }

                foreach (var clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe,0);
                    }

                    wardrobe[color][clothe]++;
                }
            }

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var war in wardrobe)
            {
                Console.WriteLine($"{war.Key} clothes:");

                foreach (var c in war.Value)
                {
                    if (war.Key == command[0] && c.Key == command[1])
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value}");
                    }
                }
            }
        }
    }
}
