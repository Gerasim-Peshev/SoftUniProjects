using System;
using System.Collections.Generic;
using System.Linq;

namespace P10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> students = new Dictionary<string, double>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string[] command = Console.ReadLine().Split("-").ToArray();

            while (command[0] != "exam finished")
            {
                if (command[1] == "banned")
                {
                    students.Remove(command[0]);
                }
                else
                {
                    string student = command[0];
                    string language = command[1];
                    double grade = double.Parse(command[2]);

                    if (!students.ContainsKey(student) && !submissions.ContainsKey(language))
                    {
                        students.Add(student, grade);
                        submissions.Add(language, 1);
                        
                    }
                    else if (students.ContainsKey(student) && students[student] < grade)
                    {
                        students[student] = grade;
                        submissions[language]++;
                    }
                    else if (!students.ContainsKey(student) && submissions.ContainsKey(language))
                    {
                        students.Add(student, grade);
                        submissions[language]++;
                    }
                    else if (students.ContainsKey(student) && submissions.ContainsKey(language))
                    {
                        submissions[language]++;
                    }
                }

                command = Console.ReadLine().Split("-").ToArray();
            }

            students = students.OrderByDescending(student => student.Value)
                               .ThenBy(student => student.Key)
                               .ToDictionary(x => x.Key, x => x.Value);

            submissions = submissions.OrderByDescending(sub => sub.Value)
                                     .ThenBy(sub => sub.Key)
                                     .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
