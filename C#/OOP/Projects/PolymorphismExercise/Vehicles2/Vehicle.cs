using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles2
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionInLitersPerKm;
        private double tankCapacity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value > this.tankCapacity)
                {
                    this.tankCapacity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get {return this.fuelConsumptionInLitersPerKm; } 
            set { this.fuelConsumptionInLitersPerKm = value; }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                this.tankCapacity = value;
            }
        }
        public virtual void Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double quantity)
        {
            if (quantity < 1)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.FuelQuantity + quantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += quantity;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
