using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car: ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorse;
        private int maxHorse;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorse = minHorsePower;
            this.maxHorse = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                else
                {
                    this.model = value;
                }
            }
        }
        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.minHorse || value > this.maxHorse)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                else
                {
                    this.horsePower = value;
                }
            }

        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.cubicCentimeters / this.horsePower * laps;
        }
    }
}
