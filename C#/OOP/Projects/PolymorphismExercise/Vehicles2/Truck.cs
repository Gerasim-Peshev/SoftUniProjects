using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles2
{
    public class Truck : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 1.6;
        private static readonly double QTY_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + ADDITIONAL_CONSUMPTION, tankCapacity)
        { }

        public override void Refuel(double quantity)
        {
            if (quantity * QTY_MODIFIER < 1)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.FuelQuantity + (quantity * QTY_MODIFIER) > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += (quantity * QTY_MODIFIER);
            }
        }
    }
}
