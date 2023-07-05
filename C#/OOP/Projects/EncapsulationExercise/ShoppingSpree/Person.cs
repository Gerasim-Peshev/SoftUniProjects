using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }

        public List<Product> Bag => bag;

        public void AddToBag(Product product)
        {
            if (Money - product.Cost < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return;
            }

            Money -= product.Cost;
            bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }
}
