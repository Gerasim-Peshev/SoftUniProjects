using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;
        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Energy
        {
            get => this.energy;
            protected set
            {
                this.energy = value;
                if (this.energy < 0)
                {
                    this.energy = 0;
                }
            }
        }
        public ICollection<IDye> Dyes
        {
            get => this.dyes;
        }
        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Dyes: {this.Dyes.Count(x => x.IsFinished() == false)} not finished");
            return sb.ToString().TrimEnd();
        }
    }
}
