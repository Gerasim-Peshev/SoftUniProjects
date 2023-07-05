using System;
using System.Collections.Generic;
using System.Linq;

namespace P09PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split().ToList();
            var cmd = Console.ReadLine();
            while (cmd != "Party!")
            {
                var command = cmd.Split();
                switch (command[0])
                {
                    case "Double":
                        switch (command[1])
                        {
                            case "StartsWith":
                                var sortedList1 = new List<string>();
                                sortedList1.AddRange(people.Where(x=>x.StartsWith(command[2])));
                                var lenght1 = sortedList1.Count;
                                for (int i = 0; i < lenght1; i++)
                                {
                                    sortedList1.Insert(i+1,sortedList1[i]);
                                }
                                people = sortedList1;
                                break;
                            case "EndsWith":
                                var sortedList2 = new List<string>();
                                sortedList2.AddRange(people.Where(x => x.EndsWith(command[2])));
                                var lenght2 = people.Count;
                                for (int i = 0; i < lenght2; i++)
                                {
                                    sortedList2.Insert(i + 1, sortedList2[i]);
                                }
                                people = sortedList2;
                                break;
                            case "Length":
                                var sortedList3 = new List<string>();
                                //sortedList3.AddRange(people.Where(x=>x.Length == int.Parse(command[2])).ToList());
                                var lenght = people.Count;
                                for (int i = 0; i < lenght; i++)
                                {
                                    sortedList3.Add(people[i]);
                                    if (people[i].Length == int.Parse(command[2]))
                                    {
                                        sortedList3.Insert(i+1,people[i]);
                                    }
                                }
                                people = sortedList3;
                                break;
                        }
                        break;
                    case "Remove":
                        switch (command[1])
                        {
                            case "StartsWith":
                                var sortedList1 = new List<string>();
                                sortedList1.AddRange(people.Where(x => x.First().ToString() != command[2]).ToList());
                                people = sortedList1;
                                break;
                            case "EndsWith":
                                var sortedList2 = new List<string>();
                                sortedList2.AddRange(people.Where(x => x.Last().ToString() != command[2]).ToList());
                                people = sortedList2;
                                break;
                            case "Length":
                                var sortedList3 = new List<string>();
                                sortedList3.AddRange(people.Where(x => x.Length != int.Parse(command[2])).ToList());
                                people = sortedList3;
                                break;
                        }
                        break;
                }

                cmd = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ",people)} are going to the party!");
            }
        }
    }
}
