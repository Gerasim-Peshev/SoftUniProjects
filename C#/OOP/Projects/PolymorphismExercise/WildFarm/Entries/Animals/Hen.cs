using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Entries.Foods;

namespace WildFarm.Entries.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine($"Cluck");
        }

        public override void Eat(Food food)
        {
            this.Weight += 0.35 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
