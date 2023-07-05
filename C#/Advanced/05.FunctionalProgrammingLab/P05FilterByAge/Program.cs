using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace P04AddVAT
{
    class Student
    {
        public Student(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                people.Add(new Student(line[0],int.Parse(line[1])));
            }

            var oldYong = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var outputType = Console.ReadLine();

            Func<Student, int, bool> olderOrYonger = GetYongerOrOlder(oldYong);
            people = people.Where(x => olderOrYonger(x, age)).ToList();

            Action<Student> printer = GetHowToPrint(outputType);
            people.ForEach(printer);
        }

        private static Action<Student> GetHowToPrint(string outputType)
        {
            switch (outputType)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age":
                    return s => Console.WriteLine(s.Age);
                case "name age":
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default:
                    return null;
            }
        }

        public static Func<Student,int,bool> GetYongerOrOlder(string oldYon)
        {
            switch (oldYon)
            {
                case "older":
                    return (s, age) => s.Age >= age;
                case "younger":
                    return (s, age) => s.Age < age;
                default:
                    return null;
            }
        }
    }
}
