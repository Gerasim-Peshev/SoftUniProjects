using System;
using System.Collections.Generic;
using System.Linq;

namespace P07OrderByAge
{
    class Program
    {
        class Person
        {
            public Person(string firstName, string id, int age)
            {
                Firstname = firstName;
                ID = id;
                Ages = age;
            }
            public string Firstname { get; set; }
            public string ID { get; set; }
            public int Ages { get; set; }
        }
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (cmd[0] != "End")
            {
                bool check = false;
                foreach (Person person in persons)
                {
                    if (person.ID == cmd[1])
                    {
                        person.Firstname = cmd[0];
                        person.Ages = int.Parse(cmd[2]);
                        check = true;
                    }
                }

                if (check)
                {
                    cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                persons.Add(new Person(cmd[0], cmd[1], int.Parse(cmd[2])));
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            persons = persons.OrderBy(x => x.Ages).ToList();

            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.Firstname} with ID: {person.ID} is {person.Ages} years old.");
            }
        }
    }
}
