using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P06VehicleCatalogue
{
    class Program
    {
        class Vehicle
        {
            public Vehicle(string type, string model, string color, double hp)
            {
                Type = type;
                Model = model;
                Color = color;
                HP = hp;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double HP { get; set; }
        }

        class Truck
        {
            public Truck(string type, string model, string color, double hp)
            {
                Type = type;
                Model = model;
                Color = color;
                HP = hp;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double HP { get; set; }
        }
        static void Main(string[] args)
        {

            //33/100
            List<Vehicle> vehivles = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "End")
            {
                vehivles.Add(new Vehicle(cmd[0], cmd[1], cmd[2], int.Parse(cmd[3])));
                cmd = Console.ReadLine().Split();
            }

            cars = vehivles.Where(vehicle => vehicle.Type == "car").ToList();
            trucks = vehivles.Where(vehicle => vehicle.Type == "truck").ToList();
            string cmd2 = Console.ReadLine();

            while (cmd2 != "Close the Catalogue")
            {
                string model = cmd2;

                Vehicle car = cars.FirstOrDefault(car => car.Model == model);
                Vehicle truck = trucks.FirstOrDefault(truck => truck.Model == model);

                if (car != null)
                {
                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HP}");
                }
                if (truck != null)
                {
                    Console.WriteLine($"Type: Truck");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.HP}");
                }

                cmd2 = Console.ReadLine();

            }


            double carHPSum = 0;
            double truckHPSum = 0;
            if (cars.Count > 0)
            {
                foreach (Vehicle car in cars)
                {
                    carHPSum += car.HP;
                }
                Console.WriteLine($"Cars have average horsepower of: {carHPSum / cars.Count:f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                foreach (Vehicle truck in trucks)
                {
                    truckHPSum += truck.HP;
                }

                Console.WriteLine($"Trucks have average horsepower of: {truckHPSum / trucks.Count:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
