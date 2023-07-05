using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IFish> fishes = new List<IFish>();
        private ICollection<IDecoration> decorations = new List<IDecoration>();
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
        {
            get
            {
                var sum = 0;
                foreach (var decoration in decorations)
                {
                    sum += decoration.Comfort;
                }

                return sum;
            }
        }
        public ICollection<IDecoration> Decorations
        {
            get => this.decorations;
        }
        public ICollection<IFish> Fish
        {
            get => this.fishes;
        }
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
            Fish.Add(fish);

        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            if (Fish.Count == 0)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", Fish)}");
            }
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();

        }
    }
}
