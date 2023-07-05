using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                var name = Console.ReadLine();
                var typeOfHero = Console.ReadLine();
                var hero = Factory(name, typeOfHero);
                if (hero == null)
                {
                    Console.WriteLine($"Invalid hero!");
                }
                else
                {
                    heroes.Add(Factory(name, typeOfHero));
                    n--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int sum = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sum += hero.Power;
            }

            Console.WriteLine(sum >= bossPower ? "Victory!" : "Defeat...");
        }

        public static BaseHero Factory(string name, string typeOfHero)
        {
            if (typeOfHero == "Druid")
            {
                return new Druid(name);
            }
            else if (typeOfHero == "Paladin")
            {
                return new Paladin(name);
            }
            else if (typeOfHero == "Rogue")
            {
                return new Rogue(name);
            }
            else if (typeOfHero == "Warrior")
            {
                return new Warrior(name);
            }
            else
            {
                return null;
            }
        }
    }
}
