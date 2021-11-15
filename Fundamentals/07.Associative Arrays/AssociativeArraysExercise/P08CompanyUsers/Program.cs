using System;
using System.Collections.Generic;
using System.Linq;

namespace P08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commands = command.Split(" -> ").ToArray();
                string companyName = commands[0];
                string id = commands[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(id))
                {
                    companies[companyName].Add(id);
                }

                command = Console.ReadLine();
            }

            companies = companies.OrderBy(key => key.Key).ThenBy(val=>val.Value).ToDictionary(c => c.Key, c => c.Value);

            for (int i = 0; i < companies.Keys.Count; i++)
            {
                Console.WriteLine($"{companies.ElementAt(i).Key}");
                for (int j = 0; j < companies.ElementAt(i).Value.Count; j++)
                {
                    Console.WriteLine($"-- {companies[companies.ElementAt(i).Key].ElementAt(j)}");
                }
            }
        }
    }
}
