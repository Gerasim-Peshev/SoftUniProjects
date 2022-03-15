using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Persons { get; set; }

        public Family()
        {
            Persons = new List<Person>();
        }
        public void AddMember(Person person)
        {
            Persons.Add(person);
        }

        public Person GetOldestMember()
        {
            var person = new Person();
            person = Persons.OrderByDescending(x => x.Age).FirstOrDefault();
            return person;
        }

        public List<Person> GetPersonsOlderThan(int age)
        {
            var persons = new List<Person>();
            persons = Persons.OrderBy(x => x.Name).Where(x => x.Age > age).ToList();
            return persons;
        }
    }
}
