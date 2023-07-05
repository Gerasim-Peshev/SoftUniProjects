using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }
        public string FullName
        {
            get { return this.fullName; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                else
                {
                    this.fullName = value;
                }
            }
        }
        public IFormulaOneCar Car
        {
            get
            {
                return this.car;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                else
                {
                    this.car = value;
                }
            }
        }
        public int NumberOfWins { get; private set; }

        public bool CanRace { get; set; } = false;
        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }

        public override string ToString()
        {
            return $"Pilot {this.fullName} has {this.NumberOfWins} wins.";
        }
    }
}
