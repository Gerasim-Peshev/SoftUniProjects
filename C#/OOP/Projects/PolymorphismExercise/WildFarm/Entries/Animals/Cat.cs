using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Entries.Foods;

namespace WildFarm.Entries.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine($"Meow");
        }

        public override void Eat(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.Weight += 0.3 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
