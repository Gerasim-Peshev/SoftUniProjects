using System;
using System.Text;
using Vehicles2;

public class Program
{
    static void Main()
    {
        Car car = (Car)Factory();
        Truck truck = (Truck)Factory();
        Bus bus = (Bus) Factory();
        int cnt = int.Parse(Console.ReadLine());

        StringBuilder str = new StringBuilder();

        while (cnt > 0)
        {
            string command = Console.ReadLine().Trim();
            string[] data = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = data[0].ToLower();
            string typeOfVehicle = data[1];
            double argument = double.Parse(data[2]);

            if (action == "refuel")
            {
                switch (typeOfVehicle)
                {
                    case "Car":
                        car.Refuel(argument);
                        break;
                    case "Truck":
                        truck.Refuel(argument);
                        break;
                    case "Bus":
                        bus.Refuel(argument);
                        break;
                }
            }
            else if (action == "drive")
            {
                switch (typeOfVehicle)
                {
                    case "Car":
                        car.Drive(argument);
                        break;
                    case "Truck":
                        truck.Drive(argument);
                        break;
                    case "Bus":
                        bus.DriveWithPeople(argument);
                        break;
                }
            }
            else
            {
                bus.Drive(argument);
            }

            cnt--;
        }
        //Console.WriteLine(str.ToString().Trim());
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static Vehicle Factory()
    {
        string[] part = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQty = double.Parse(part[1]);
        double fuelConsumption = double.Parse(part[2]);
        double tankCapacity = double.Parse(part[3]);
        switch (part[0])
        {
            case "Car":
                return new Car(fuelQty, fuelConsumption, tankCapacity);
            case "Truck":
                return new Truck(fuelQty, fuelConsumption,tankCapacity);
            case "Bus":
                return new Bus(fuelQty, fuelConsumption, tankCapacity);
            default:
                return null;
        }
    }
}