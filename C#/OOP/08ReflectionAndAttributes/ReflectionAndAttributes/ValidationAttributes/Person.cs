﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }
        [MyRange(12,90)]
        public int Age { get; set; }
    }
}
