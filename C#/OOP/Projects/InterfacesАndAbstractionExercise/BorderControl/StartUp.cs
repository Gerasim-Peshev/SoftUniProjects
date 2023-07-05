using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> years = new List<string>();

            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "Citizen")
                {
                    var name = command[1];
                    var age = int.Parse(command[2]);
                    var id = command[2];
                    var date = command[4];
                    ICitizen citizen = new Citizen(name, age, id, date);
                    years.Add(date);
                }
                else if (command[0] == "Robot")
                {
                    var model = command[1];
                    var id = command[2];
                    IRobot robot = new Robot(model, id);
                }
                else if (command[0] == "Pet")
                {
                    var name = command[1];
                    var date = command[2];
                    IPet pet = new Pet(name, date);
                    years.Add(date);
                }

                cmd = Console.ReadLine();
            }

            string idToRemove = Console.ReadLine();

            List<string> removedIds = years.Where(x => x.EndsWith(idToRemove)).ToList();

            if (removedIds.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, removedIds));
            }
        }
    }
}
