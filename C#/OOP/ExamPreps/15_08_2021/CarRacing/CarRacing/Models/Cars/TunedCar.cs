using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }

        //public override void Drive()
        //{
        //    this.FuelAvailable -= this.FuelConsumptionPerRace;
        //    double tempHP = this.HorsePower;
        //    this.HorsePower -= (int)(tempHP * 0.03);
        //}
    }
}
