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
                if (StudentExist(students, command[0], command[1]))
                {
                    Student student = GetStudent(students, command[0], command[1]);

                    student.FirstName = command[0];
                    student.LastName = command[1];
                    student.Ages = int.Parse(command[2]);
                    student.Town = command[3];
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = command[0],
                        LastName = command[1],
                        Ages = int.Parse(command[2]),
                        Town = command[3]
                    };

                    students.Add(student);
                }

                //Student student = new Student()
                //{
                //    FirstName = command[0],
                //    LastName = command[1],
                //    Ages = int.Parse(command[2]),
                //    Town = command[3]
                //};
                //students.Add(student);

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

        static bool StudentExist(List<Student> students, string firstname, string lastname)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstname && student.LastName == lastname)
                {
                    return true;
                }
            }

            return false;
        }
        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
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