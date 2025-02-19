﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int n)
        {
            Capacity = n;
            Cars = new List<Car>();
        }
        public List<Car> Cars { get { return cars;} set { cars = value; } }
        public int Capacity { get { return capacity;} set { capacity = value; } }
        public int Count => Cars.Count();

        public string AddCar(Car car)
        {
            if (Cars.Any(x=>x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (Cars.Count >= Capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.All(x => x.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
            }
        }
    }
}
