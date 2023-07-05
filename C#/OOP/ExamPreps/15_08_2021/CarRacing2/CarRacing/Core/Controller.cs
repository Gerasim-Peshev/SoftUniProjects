using System;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using System.Linq;
using CarRacing.Models.Maps;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars = new CarRepository();
        private RacerRepository racers = new RacerRepository();
        private IMap map = new Map();

        public Controller()
        {
            
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == "SuperCar")
            {
                this.cars.Add(new SuperCar(make,model,VIN,horsePower));
            }
            else if (type == "TunedCar")
            {
                this.cars.Add(new TunedCar(make,model,VIN,horsePower));
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var carTOFind = cars.FindBy(carVIN);
            if (carTOFind == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type == "ProfessionalRacer")
            {
                racers.Add(new ProfessionalRacer(username, carTOFind));
            }
            else if (type == "StreetRacer")
            {
                racers.Add(new StreetRacer(username, carTOFind));
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racer1 = racers.FindBy(racerOneUsername);
            var racer2 = racers.FindBy(racerTwoUsername);

            if (racer1 == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racer2 == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            else
            {
                return this.map.StartRace(racer1, racer2);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in this.racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(x=>x.Username))
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
