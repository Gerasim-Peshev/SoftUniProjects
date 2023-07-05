using System;
using System.Collections.Generic;
using System.Linq;

namespace P05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registered = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                string action = command[0];
                string name = command[1];
                string plate = "";
                if (command.Length == 3)
                {
                    plate = command[2];
                }

                if (action == "register")
                {
                    if (!registered.ContainsKey(name))
                    {
                        registered.Add(name, plate);
                        Console.WriteLine($"{name} registered {plate} successfully");
                    }
                    else if (registered.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registered[name]}");
                    }
                }
                else if (action == "unregister")
                {
                    if (!registered.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        registered.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }

                }
            }

            foreach (var registere in registered)
            {
                Console.WriteLine($"{registere.Key} => {registere.Value}");
            }
        }
    }
}
