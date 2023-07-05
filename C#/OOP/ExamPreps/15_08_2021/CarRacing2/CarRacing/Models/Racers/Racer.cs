using System;
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

                this.username = value;
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

                this.racingBehavior = value;
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

                this.drivingExperience = value;
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

                this.car = value;
            }
        }
        public virtual void Race()
        {
            
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable - this.Car.FuelConsumptionPerRace < 0)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            return $"{this.GetType().Name}: {this.Username}" +
                   $"--Driving behavior: {this.RacingBehavior}" +
                   $"--Driving experience: {this.DrivingExperience}" +
                   $"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})".TrimEnd();

        }
    }
}
