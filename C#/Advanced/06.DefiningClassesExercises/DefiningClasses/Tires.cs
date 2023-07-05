using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        public Tires(float pressure, int age)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
