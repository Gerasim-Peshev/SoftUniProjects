using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnys;
        private EggRepository eggs;
        private int coloredEggs;

        public Controller()
        {
            this.bunnys = new BunnyRepository();
            this.eggs = new EggRepository();
            coloredEggs = 0;
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            else
            {
                this.bunnys.Add(bunny);
                return string.Format(OutputMessages.BunnyAdded, bunnyType, bunny.Name);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnys.FindByName(bunnyName);

            IDye dye = new Dye(power);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            else
            {
                bunny.AddDye(dye);
                return string.Format(OutputMessages.DyeAdded, dye.Power, bunny.Name);
            }
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, egg.Name);
        }

        public string ColorEgg(string eggName)
        {
            Workshop workshop = new Workshop();

            IEgg egg = this.eggs.FindByName(eggName);
            List<IBunny> bunnysReady = this.bunnys.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();
            IBunny bunny = null;
            if (bunnysReady.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            else
            {
                bunny = bunnysReady.First();
                while (true)
                {
                    if (egg.IsDone() || bunnysReady.Count == 0)
                    {
                        if (egg.IsDone() == true)
                        {
                            this.coloredEggs++;
                            return string.Format(OutputMessages.EggIsDone, egg.Name);
                        }
                        else
                        {
                            return string.Format(OutputMessages.EggIsNotDone, egg.Name);
                        }
                    }


                    if (bunny.Energy == 0)
                    {
                        this.bunnys.Remove(bunny);
                        bunnysReady.Remove(bunny);
                        bunny = bunnysReady.First();
                    }

                    if (bunny.Dyes.Any(x => x.IsFinished() == false))
                    {
                        workshop.Color(egg, bunny);
                    }
                    else
                    {
                        bunnysReady.Remove(bunny);
                        bunny = bunnysReady.FirstOrDefault();
                    }
                }
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.coloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in this.bunnys.Models.Where(x=>x.Energy > 0))
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
