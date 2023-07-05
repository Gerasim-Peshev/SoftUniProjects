using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get; set; }
        public int Load { get; }
        public IReadOnlyCollection<Item> Items
        {
            get => this.items;
        }
        public void AddItem(Item item)
        {
            if (this.items.Count < Capacity)
            {
                this.items.Add(item);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            else
            {
                this.items.Remove(item);
                return item;
            }
        }
    }
}
