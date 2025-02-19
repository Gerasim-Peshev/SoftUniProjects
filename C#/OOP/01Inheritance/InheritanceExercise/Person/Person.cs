﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > -1)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format($"Name: {this.Name}, Age: {this.Age}"));
            return sb.ToString();
        }
    }
}
