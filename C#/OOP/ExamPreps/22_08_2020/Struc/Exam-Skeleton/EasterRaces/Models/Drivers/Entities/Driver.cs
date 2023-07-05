using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;
        public Driver(string name)
        {
            this.Name = name;
            this.canParticipate = false;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value));
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public ICar Car
        {
            get => this.car;
        }
        public int NumberOfWins
        {
            get => this.numberOfWins;
        }
        public bool CanParticipate
        {
            get => this.canParticipate;
        }
        public void WinRace()
        {
            this.numberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            else
            {
                this.car = car;
                this.canParticipate = true;
            }
        }
    }
}
