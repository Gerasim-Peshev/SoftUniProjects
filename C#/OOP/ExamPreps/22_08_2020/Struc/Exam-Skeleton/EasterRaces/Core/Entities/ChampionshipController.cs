using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            else
            {
                this.drivers.Add(new Driver(driverName));
                return string.Format(OutputMessages.DriverCreated, driverName);
            }
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            else
            {
                this.cars.Add(car);
                return string.Format(OutputMessages.CarCreated, type, model);
            }
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            else
            {
                this.races.Add(race);
                return string.Format(OutputMessages.RaceCreated, name);
            }
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else
            {
                race.AddDriver(driver);
                return string.Format(OutputMessages.DriverAdded, driverName, raceName);
            }
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = this.cars.GetByName(carModel);
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            else
            {
                driver.AddCar(car);
                return string.Format(OutputMessages.CarAdded, driverName, carModel);
            }
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName));
            }
            else
            {
                List<IDriver> secondDrivers  = new List<IDriver>(this.drivers.GetAll().ToList().OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)));
                this.races.Remove(race);

                this.drivers.GetAll()
                    .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                    .FirstOrDefault()
                    .WinRace();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, secondDrivers[0].Name, race.Name));
                sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, secondDrivers[1].Name, race.Name));
                sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, secondDrivers[2].Name, race.Name));

                return sb.ToString().TrimEnd();
            }
        }
    }
}
