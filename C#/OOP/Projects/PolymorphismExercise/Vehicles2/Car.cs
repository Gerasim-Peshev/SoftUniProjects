using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles2
{
    public class Car : Vehicle
    {
        private static readonly double ADDITIONAL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption + ADDITIONAL_CONSUMPTION,tankCapacity)
        { }
    }
}
