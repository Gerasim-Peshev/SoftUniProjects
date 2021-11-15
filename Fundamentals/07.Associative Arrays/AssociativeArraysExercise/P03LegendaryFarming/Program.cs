using System;
using System.Collections.Generic;
using System.Linq;

namespace P03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> legendaryes = new Dictionary<string, double>();
            legendaryes.Add("fragments", 0);
            legendaryes.Add("shards", 0);
            legendaryes.Add("motes", 0);
            Dictionary<string, double> junk = new Dictionary<string, double>();


            while (legendaryes["fragments"] < 250 && legendaryes["shards"] < 250 && legendaryes["motes"] < 250)
            {
                List<string> command = Console.ReadLine().Split().ToList();

                for (int j = 0; j < command.Count; j += 2)
                {
                    double quantity = double.Parse(command[j]);
                    string item = command[j + 1].ToLower();

                    if (item == "fragments" || item == "shards" || item == "motes")
                    {
                        switch (item)
                        {
                            case "fragments":
                                legendaryes[item] += quantity;
                                break;
                            case "shards":
                                legendaryes[item] += quantity;
                                break;
                            case "motes":
                                legendaryes[item] += quantity;
                                break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(item))
                        {
                            junk.Add(item, quantity);
                        }
                        else
                        {
                            junk[item] += quantity;
                        }
                    }

                    if (legendaryes["fragments"] >= 250 || legendaryes["shards"] >= 250 || legendaryes["motes"] >= 250)
                    {
                        break;
                    }
                }
            }

            legendaryes = legendaryes.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);

            if (legendaryes.Values.ElementAt(0) == legendaryes.Values.ElementAt(1))
            {
                legendaryes = legendaryes.OrderBy(item => item.Key).ToDictionary(item => item.Key, item => item.Value);
            }

            KeyValuePair<string, double> Item = legendaryes.FirstOrDefault();
            if (Item.Key == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
                legendaryes["fragments"] -= 250;
            }
            else if (Item.Key == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
                legendaryes["shards"] -= 250;
            }
            else if (Item.Key == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
                legendaryes["motes"] -= 250;
            }


            foreach (var item in legendaryes.OrderByDescending(item => item.Value).ThenBy(item => item.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            

            foreach (var trash in junk.OrderBy(trash => trash.Key))
            {
                Console.WriteLine($"{trash.Key}: {trash.Value}");
            }
        }
    }
}
