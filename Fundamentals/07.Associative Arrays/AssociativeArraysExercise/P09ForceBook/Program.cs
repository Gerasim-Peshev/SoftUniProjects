using System;
using System.Collections.Generic;
using System.Linq;

namespace P09ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();


            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                List<string> cmds = new List<string>();
                string name = "";
                string side = "";
                if (command.Contains("->"))
                {
                    cmds = command.Split(" -> ").ToList();
                    name = cmds[0];
                    side = cmds[1];

                    if (!sides.Values.Any(names => names.Contains(name)))
                    {
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new List<string>());
                        }
                        sides[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var sidee in sides.Where(sidess => sidess.Value.Contains(name)))
                        {
                            sidee.Value.Remove(name);
                        }

                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side,new List<string>());
                        }
                        sides[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                }
                else if (command.Contains(" | "))
                {
                    cmds = command.Split(" | ").ToList();
                    name = cmds[1];
                    side = cmds[0];
                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                    }

                    if (!sides[side].Contains(name) && !sides.Values.Any(names => names.Contains(name)))
                    {
                        sides[side].Add(name);
                    }
                }

                command = Console.ReadLine();
            }

            sides = sides.Where(side => side.Value.Count > 0)
                         .OrderByDescending(side => side.Value.Count)
                         .ThenBy(side => side.Key)
                         .ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < sides.Count; i++)
            {
                sides[sides.ElementAt(i).Key] = sides[sides.ElementAt(i).Key]
                                               .OrderBy(user => user)
                                               .ToList();
            }

            foreach (var side in sides)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
