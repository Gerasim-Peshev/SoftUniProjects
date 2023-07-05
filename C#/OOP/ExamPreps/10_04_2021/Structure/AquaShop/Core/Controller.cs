using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorations.Add(new Plant());
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decor = this.decorations.FindByType(decorationType);
            var aqua = this.aquariums.Find(x => x.Name == aquariumName);
            if (decor == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aqua.Decorations.Add(decor);
            this.decorations.Remove(decor);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aqua = this.aquariums.Find(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if (aqua.GetType().Name != "FreshwaterAquarium")
                {
                    return OutputMessages.UnsuitableWater;
                }
                aqua.AddFish(new FreshwaterFish(fishName,fishSpecies,price));
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aqua.GetType().Name != "SaltwaterAquarium")
                {
                    return OutputMessages.UnsuitableWater;
                }
                aqua.AddFish(new SaltwaterFish(fishName,fishSpecies,price));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

        }

        public string FeedFish(string aquariumName)
        {
            var aqua = this.aquariums.Find(x => x.Name == aquariumName);
            int count = 0;
            foreach (var fish in aqua.Fish)
            {
                fish.Eat();
                count++;
            }

            return string.Format(OutputMessages.FishFed, count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aqua = this.aquariums.Find(x => x.Name == aquariumName);
            var sum = aqua.Fish.Sum(x => x.Price) + aqua.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
