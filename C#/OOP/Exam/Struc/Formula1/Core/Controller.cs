using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Models.FormulaOneCars;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            IPilot pilot = new Pilot(fullName);
            if (this.pilotRepository.FindByName(pilot.FullName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotExistErrorMessage, pilot.FullName));
            }
            else
            {
                this.pilotRepository.Add(pilot);
                return string.Format(OutputMessages.SuccessfullyCreatePilot, pilot.FullName);
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            if (this.carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, car.Model));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            else
            {
                this.carRepository.Add(car);
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, car.Model);
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);
            if (this.raceRepository.FindByName(race.RaceName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceExistErrorMessage, race.RaceName));
            }
            else
            {
                this.raceRepository.Add(race);
                return string.Format(OutputMessages.SuccessfullyCreateRace, race.RaceName);
            }
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = this.carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else if (car == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            else
            {
                pilot.AddCar(car);
                this.carRepository.Remove(car);
                return string.Format(OutputMessages.SuccessfullyPilotToCar, pilot.FullName, car.GetType().Name,
                                     car.Model);
            }
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (pilot == null || pilot.CanRace == false || race.Pilots.FirstOrDefault(x=>x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            else
            {
                race.AddPilot(pilot);
                return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilot.FullName, race.RaceName);
            }
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);


            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            else if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, race.RaceName));
            }
            else
            {
                List<IPilot> pilots = race.Pilots.ToList().OrderByDescending(x=>x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

                race.TookPlace = true;
                this.pilotRepository.FindByName(pilots[0].FullName).WinRace();

                StringBuilder sb = new StringBuilder();
                sb.Append(
                    $"Pilot {pilots[0].FullName} wins the {race.RaceName} race." + Environment.NewLine +
                    $"Pilot {pilots[1].FullName} is second in the {race.RaceName} race." + Environment.NewLine +
                    $"Pilot {pilots[2].FullName} is third in the {race.RaceName} race.");
                return sb.ToString().TrimEnd();
            }
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models.Where(x=>x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
