using System;
using System.Collections.Generic;
using System.Text;

namespace P01ListyIterator
{
    public class Person : IComparable
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town; 
        }

        public int CompareTo(object other)
        {
            throw new NotImplementedException();
        }
    }
}
