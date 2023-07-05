using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace P06StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Box> boxes = new List<Box>();

            while (command[0] != "end")
            {
                string serianNumber = command[0];
                string name = command[1];
                int quantity = int.Parse(command[2]);
                decimal price = decimal.Parse(command[3]);

                Box box = new Box()
                {
                    SerialNumber = serianNumber,
                    
                    Quantity = quantity,
                    PriceBox = quantity * price
                };
                box.Item = new Item()
                {
                    Name = name,
                    Price = price
                };

                boxes.Add(box);

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            boxes = boxes.OrderByDescending(x => x.PriceBox).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
