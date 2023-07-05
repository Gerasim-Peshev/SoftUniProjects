using System;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;
        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get { return this.make; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                this.model = value;
            }
        }
        public string VIN
        {
            get { return this.vin; }
            set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }
        public int HorsePower
        {
            get { return this.horsePower; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }
        public double FuelAvailable
        {
            get { return this.fuelAvailable; }
            set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }

                this.fuelAvailable = value;
            }
        }
        public double FuelConsumptionPerRace
        {
            get { return this.fuelConsumptionPerRace; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                else
                {
                    this.fuelConsumptionPerRace = value;
                }
            }
        }
        public virtual void Drive()
        {
            this.FuelAvailable -= this.fuelConsumptionPerRace;
        }
    }
}
