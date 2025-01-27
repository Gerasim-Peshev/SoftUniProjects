using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace P04Students
{
    class Program
    {
        class Student
        {
            public Student(string First, string Last, double Grad)
            {
                FirstName = First;
                LastName = Last;
                Grade = Grad;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            //string[] cmd = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                Student student = new Student(cmd[0],cmd[1],double.Parse(cmd[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
