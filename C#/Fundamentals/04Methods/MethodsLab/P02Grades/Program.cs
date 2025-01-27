using System;

namespace P02Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Grade(grade);
        }

        static void Grade(double grade)
        {
            Console.WriteLine(grade < 3 ? "Fail" : grade >= 3 && grade < 3.5 ? "Poor" : grade > 3.49 && grade < 4.5 ? "Good" : grade > 4.49 && grade < 5.5 ? "Very good" : "Excellent");
        }
    }
}
