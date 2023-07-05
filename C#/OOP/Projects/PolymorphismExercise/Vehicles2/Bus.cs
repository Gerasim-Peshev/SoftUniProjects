using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles2
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void DriveWithPeople(double kilometres)
        {
            double litresToUse = (this.FuelConsumption + 1.4) * kilometres;
            if (litresToUse > this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= litresToUse;
                Console.WriteLine($"{this.GetType().Name} travelled {kilometres} km");
            }
        }
    }
}
