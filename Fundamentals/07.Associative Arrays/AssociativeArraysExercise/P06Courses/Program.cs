using System;
using System.Collections.Generic;
using System.Linq;

namespace P06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> inputs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToList();

                string course = inputs[0];
                string name = inputs[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(name);

                command = Console.ReadLine();
            }

            courses = courses.OrderByDescending(courseName => courseName.Value.Count)
                             .ToDictionary(x => x.Key, x => x.Value);
            courses = courses.ToDictionary(d => d.Key, d => (List<string>)d.Value.OrderBy(v => v).ToList());

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{courses.ElementAt(i).Key}: {courses.ElementAt(i).Value.Count}");
                for (int j = 0; j < courses.ElementAt(i).Value.Count; j++)
                {
                    Console.WriteLine($"-- {courses[courses.ElementAt(i).Key].ElementAt(j)}");
                }
            }
        }
    }
}
