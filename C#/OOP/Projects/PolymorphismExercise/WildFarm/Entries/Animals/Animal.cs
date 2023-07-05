using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Entries.Foods;

namespace WildFarm.Entries.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void ProduceSound();
        public abstract void Eat(Food food);

        public abstract override string ToString();
    }
}
