using System;
using System.Collections.Generic;
using System.Linq;

namespace P07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                }
                students[student].Add(grade);
            }

            students = students.Where(student => student.Value.Average() > 4.49).OrderByDescending(grade => grade.Value.Average()).ToDictionary(c => c.Key, c => c.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
