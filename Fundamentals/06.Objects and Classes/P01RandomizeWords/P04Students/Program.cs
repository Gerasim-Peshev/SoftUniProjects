using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "end")
            {
                Student student = new Student()
                {
                    FirstName = command[0],
                    LastName = command[1],
                    Ages = int.Parse(command[2]),
                    Town = command[3]
                };
                students.Add(student);
                
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string town = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.Town == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Ages} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ages { get; set; }
        public string Town { get; set; }
    }
}
