using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;
        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }
        public decimal Price
        {
            get => this.price;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }
        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }
}
