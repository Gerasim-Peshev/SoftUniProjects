using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var peopleToAdd = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productsToAdd = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {

                var people = new Dictionary<string, Person>();
                for (int i = 0; i < peopleToAdd.Length; i += 2)
                {
                    Person person = new Person(peopleToAdd[i], decimal.Parse(peopleToAdd[i + 1]));
                    people.Add(peopleToAdd[i], person);
                }

                var products = new Dictionary<string, Product>();
                for (int i = 0; i < productsToAdd.Length; i += 2)
                {
                    Product product = new Product(productsToAdd[i], decimal.Parse(productsToAdd[i + 1]));
                    products.Add(productsToAdd[i], product);
                }

                var cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var name = command[0];
                    var product = command[1];

                    people[name].AddToBag(products[product]);
                    cmd = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.Value.Bag.Count < 1)
                    {
                        Console.WriteLine($"{person.Key} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.Bag.Select(x => x.Name))}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
