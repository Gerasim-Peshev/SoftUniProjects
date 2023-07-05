using System;
using System.Linq;
using System.Text;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carToCreate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var truckToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            //Car,                                        Kolichestvo: 15,                        Razhod: 0.3
            Vehicle car = new Car(double.Parse(carToCreate[1]), double.Parse(carToCreate[2]));

            //Truck,                                          Kolichestvo: 100,                          Razhod: 0.9
            Vehicle truck = new Truck(double.Parse(truckToAdd[1]), double.Parse(truckToAdd[2]));

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (line[0] == "Drive")
                {
                    if (line[1] == "Car")
                    {
                        bool check = car.Drive(double.Parse(line[2]));
                        if (check)
                        {
                            Console.WriteLine($"Car travelled {line[2]} km");
                        }
                        else
                        {
                            Console.WriteLine($"Car needs refueling");
                        }
                    }
                    else if (line[1] == "Truck")
                    {
                        bool check = truck.Drive(double.Parse(line[2]));
                        if (check)
                        {
                            Console.WriteLine($"Truck travelled {line[2]} km");
                        }
                        else
                        {
                            Console.WriteLine($"Truck needs refueling");
                        }
                    }
                }
                else if (line[0] == "Refuel")
                {
                    if (line[1] == "Car")
                    {
                        car.Refuel(double.Parse(line[2]));
                    }
                    else if (line[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(line[2]));
                    }
                }
            }

            //var truckFuel = Math.Round(truck.FuelQuantity,2);
            //Console.WriteLine(sb.ToString().TrimEnd());
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        //public static double Round(double num)
        //{
        //    if (num.ToString().Last() >= 5)
        //    {
        //        return Math.Ceiling(num,2);
        //    }
        //    else
        //    {
        //        return Math.Floor(num, 2);
        //    }
        //}
    }
}
