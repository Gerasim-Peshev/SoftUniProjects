using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> FoodOrders;
        private ICollection<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.FoodOrders = new List<IBakedFood>();
            this.DrinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; }
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; set; }
        public decimal Price
        {
            get => NumberOfPeople * PricePerPerson;
        }
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
            this.Capacity -= numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            if (IsReserved)
            {
                this.FoodOrders.Add(food);
            }
        }

        public void OrderDrink(IDrink drink)
        {
            if (IsReserved)
            {
                this.DrinkOrders.Add(drink);
            }
        }

        public decimal GetBill()
        {
            decimal sum = 0;
            foreach (var foodOrder in FoodOrders)
            {
                sum += foodOrder.Price;
            }

            foreach (var drinkOrder in DrinkOrders)
            {
                sum += drinkOrder.Price;
            }

            sum += Price;
            return sum;
        }

        public void Clear()
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.IsReserved = false;
            this.Capacity = 0;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}" + Environment.NewLine +
                   $"Type: {this.GetType().Name}" + Environment.NewLine +
                   $"Capacity: {this.Capacity}" + Environment.NewLine +
                   $"Price per Person: {this.PricePerPerson:f2}";
        }
    }
}
