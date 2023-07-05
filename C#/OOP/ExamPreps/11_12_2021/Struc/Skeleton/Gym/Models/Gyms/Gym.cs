using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipments = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }
        public int Capacity { get; private set; }
        public double EquipmentWeight
        {
            get
            {
                return this.equipments.Sum(x => x.Weight);
            }
        }
        public ICollection<IEquipment> Equipment
        {
            get => this.equipments;
        }
        public ICollection<IAthlete> Athletes
        {
            get => this.athletes;
        }
        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count < Capacity)
            {
                this.athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (athletes.Count == 0)
            {
                sb.AppendLine("Athletes: No athletes");
            }
            else
            {
                StringBuilder athBuilder = new StringBuilder();
                sb.AppendLine($"Athletes: {string.Join(", ", this.athletes.Select(x => x.FullName))}");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
