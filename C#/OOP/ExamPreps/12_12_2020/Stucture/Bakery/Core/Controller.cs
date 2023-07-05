using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private ICollection<decimal> bills;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.bills = new List<decimal>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            if (type == nameof(Bread))
            {
                this.bakedFoods.Add(new Bread(name, price));
                return $"Added {name} ({type}) to the menu";
            }
            else if (type == nameof(Cake))
            {
                this.bakedFoods.Add(new Cake(name, price));
                return $"Added {name} ({type}) to the menu";
            }
            else
            {
                return null;
            }
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == nameof(Tea))
            {
                this.drinks.Add(new Tea(name, portion, brand));
                return string.Format(OutputMessages.DrinkAdded, name, brand);
            }
            else if (type == nameof(Water))
            {
                this.drinks.Add(new Water(name, portion, brand));
                return string.Format(OutputMessages.DrinkAdded, name, brand);
            }
            else
            {
                return null;
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == nameof(InsideTable))
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
                return string.Format(OutputMessages.TableAdded, tableNumber);
            }
            else if (type == nameof(OutsideTable))
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
                return string.Format(OutputMessages.TableAdded, tableNumber);
            }
            else
            {
                return null;
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(5);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            else
            {
                table.OrderFood(food);
                return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (drink == null)
            {
                return $"There is no { drinkName } { drinkBrand} available";
            }
            else
            {
                table.OrderDrink(drink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            var bill = table.GetBill();
            this.bills.Add(bill);
            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }

            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {bills.Sum()}lv";
        }
    }
}
