using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.VisualBasic.FileIO;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Trainer> trainers = new HashSet<Trainer>();

            var cmd = Console.ReadLine();
            while (cmd != "Tournament")
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                bool checkContains = false;
                foreach (var trainer1 in trainers)
                {
                    if (trainer1.Name == command[0])
                    {
                        trainer1.Pokemons.Add(new Pokemon(command[1], command[2], double.Parse(command[3])));
                        checkContains = true;
                    }
                }

                if (!checkContains)
                {
                    var trainer = new Trainer(command[0]);
                    trainer.Pokemons.Add(new Pokemon(command[1], command[2], double.Parse(command[3])));
                    trainers.Add(trainer);
                }
                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool check = false;
                    foreach (var trainerPokemon in trainer.Pokemons)
                    {
                        if (trainerPokemon.Element == cmd)
                        {
                            check = true;
                        }
                    }

                    if (check)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else if (!check)
                    {
                        foreach (var trainerPokemon in trainer.Pokemons)
                        {
                            trainerPokemon.Health -= 10;
                        }

                        trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                    }
                }
                cmd = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
