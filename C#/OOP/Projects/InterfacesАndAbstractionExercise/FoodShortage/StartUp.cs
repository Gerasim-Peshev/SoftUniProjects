using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (line.Length == 4)
                {
                    var name = line[0];
                    var age = int.Parse(line[1]);
                    var id = line[2];
                    var date = line[3];
                    citizens.Add(new Citizen(name, age, id, date));
                }
                else
                {
                    var name = line[0];
                    var age = int.Parse(line[1]);
                    var group = line[2];
                    rebels.Add(new Rebel(name,age,group));
                }
            }

            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                citizens.FirstOrDefault(x=>x.Name == cmd)?.BuyFood();
                rebels.FirstOrDefault(x=>x.Name == cmd)?.BuyFood();
                cmd = Console.ReadLine();
            }

            Console.WriteLine(citizens.Sum(x => x.Food) + rebels.Sum(x => x.Food));
        }
    }
}
