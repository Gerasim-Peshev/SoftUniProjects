using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make,string model,int hoursePower,string registrationNumber)
        {
            Make = make;
            Model = model;
            HoursePower = hoursePower;
            RegistrationNumber = registrationNumber;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HoursePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"HoursePower: {HoursePower}");
            sb.AppendLine($"RegistrationNumber: {RegistrationNumber}");
            return sb.ToString();
        }
    }
}
