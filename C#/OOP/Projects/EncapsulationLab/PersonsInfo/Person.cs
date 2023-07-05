using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > 2)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 2)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }

        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value > 649)
                {
                    salary = value;
                }
                else
                {
                   // throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age < 30)
            {
                this.salary = this.salary + (this.salary * ((percentage / 2) / 100));
            }
            else
            {
                this.salary = this.salary + (this.salary * (percentage / 100));
            }
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";
        }
    }
}
