using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Func<Tire[], double> tiresSum = (tiresAll) =>
            {
                double summedPressure = 0;
                foreach (var tire in tiresAll)
                {
                    summedPressure += tire.Pressure;
                }

                return summedPressure;
            };


            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            var cmd = Console.ReadLine();
            while (cmd != "No more tires")
            {
                var command = cmd.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                var tiress = new Tire[4];
                int count = 0;
                for (int i = 0; i < command.Length; i+=2)
                {
                    tiress[count] = new Tire(int.Parse(command[i]), double.Parse(command[i + 1]));
                    count++;
                }

                tires.Add(tiress);
                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd != "Engines done")
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var engine = new Engine(int.Parse(command[0]), double.Parse(command[1]));
                engines.Add(engine);
                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd != "Show special")
            {
                var command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var make = command[0];
                var model = command[1];
                var year = int.Parse(command[2]);
                var fuelQuantity = double.Parse(command[3]);
                var fuelConsumption = double.Parse(command[4]);
                var engineIndex = int.Parse(command[5]);
                var tiresIndex = int.Parse(command[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex],
                                  tires[tiresIndex]);
                cars.Add(car);
                cmd = Console.ReadLine();
            }

            cars = cars.Where(x => x.Year > 2016).Where(x => x.Engine.HorsePower > 330)
                       .Where(x => tiresSum(x.Tires) >= 8 && tiresSum(x.Tires) <= 10).ToList();

            foreach (var car in cars)
            {
                car.Drive(0.2);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
