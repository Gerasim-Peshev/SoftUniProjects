using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                else
                {
                    this.username = value;
                }
            }
        }
        public string RacingBehavior
        {
            get { return this.racingBehavior; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                else
                {
                    this.racingBehavior = value;
                }
            }
        }
        public int DrivingExperience
        {
            get { return this.drivingExperience; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                else
                {
                    this.drivingExperience = value;
                }
            }
        }

        public ICar Car
        {
            get { return this.car; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                else
                {
                    this.car = value;
                }
            }
        }

        public void Race()
        {

        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable - this.Car.FuelConsumptionPerRace > 0)
            {
                return true;
            }

            return false;
        }
    }
}
