using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

        public virtual bool Drive(double kilometres)
        {
            if (this.FuelConsumption * kilometres > this.FuelQuantity)
            {
                return false;
            }
            else
            {
                this.FuelQuantity -= this.FuelConsumption * kilometres;
                return true;
            }
        }

        public virtual void Refuel(double litres)
        {
            this.FuelQuantity += litres;
        }
    }
}
