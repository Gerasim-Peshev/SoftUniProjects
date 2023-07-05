using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Entries.Foods;

namespace WildFarm.Entries.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine($"Woof!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += 0.4 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
