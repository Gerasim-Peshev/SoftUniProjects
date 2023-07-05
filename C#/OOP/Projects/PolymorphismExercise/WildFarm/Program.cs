using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Entries.Animals;
using WildFarm.Entries.Foods;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            var anim = Console.ReadLine();

            while (anim != "End")
            {
                var animalInfo = anim.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                var animalType = animalInfo[0];
                var name = animalInfo[1];
                var weight = double.Parse(animalInfo[2]);

                Animal animal = null;
                if (animalType == "Cat")
                {
                    animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                }
                else if (animalType == "Owl")
                {
                    animal = new Owl(name, weight, double.Parse(animalInfo[3]));
                }
                else if (animalType == "Hen")
                {
                    animal = new Hen(name, weight, double.Parse(animalInfo[3]));
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, animalInfo[3]);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, animalInfo[3]);
                }

                animal.ProduceSound();

                var foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);

                Food food = null;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                }

                animal.Eat(food);
                animals.Add(animal);

                anim = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
