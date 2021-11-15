using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace P07VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split("/", StringSplitOptions.RemoveEmptyEntries).ToArray();

            CatalogVehicle car = new CatalogVehicle();
            CatalogVehicle truck = new CatalogVehicle();

            while (command[0] != "end")
            {
                string type = command[0];
                string brande = command[1];
                string model = command[2];
                int weightHP = int.Parse(command[3]);


                if (type == "Car")
                {

                    car.Cars.Add(new Car()
                    {
                        Brand = brande,
                        Model = model,
                        HorsePower = weightHP
                    });
                }
                else if (type == "Truck")
                {

                    truck.Trucks.Add(new Truck()
                    {
                        Brand = brande,
                        Model = model,
                        Weight = weightHP
                    });
                }

                command = Console.ReadLine().Split("/", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }


            car.Cars = car.Cars.OrderBy(x => x.Brand).ToList();
            truck.Trucks = truck.Trucks.OrderBy(x => x.Brand).ToList();
            if (car.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car ca in car.Cars)
                {
                    Console.WriteLine($"{ca.Brand}: {ca.Model} - {ca.HorsePower}hp");
                }
            }

            if (truck.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck tru in truck.Trucks)
                {
                    Console.WriteLine($"{tru.Brand}: {tru.Model} - {tru.Weight}kg");
                }
            }
        }
    }

    class CatalogVehicle
    {

        public CatalogVehicle()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
}
