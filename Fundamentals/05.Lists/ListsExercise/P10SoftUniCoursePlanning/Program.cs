using System;
using System.Collections.Generic;
using System.Linq;

namespace P10SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] command = Console.ReadLine().Split(":").ToArray();

            while (command[0] != "course start")
            {
                

                if (command[0] == "Add")
                {
                    if (!schedule.Contains(command[1]))
                    {
                        schedule.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    if (!schedule.Contains(command[1]))
                    {
                        if (int.Parse(command[2]) < schedule.Count && int.Parse(command[2]) >= 0)
                        {
                            schedule.Insert(int.Parse(command[2]), command[1]);
                        }
                    }
                }
                else if (command[0] == "Remove")
                {
                    schedule.Remove(command[1]);
                    schedule.Remove($"{command[1]}-Exercise");

                }
                else if (command[0] == "Swap")
                {
                    int indexOfFirstCourse = schedule.IndexOf(command[1]);
                    int indexOfSecondCourse = schedule.IndexOf(command[2]);

                    schedule[indexOfFirstCourse] = command[2];
                    schedule[indexOfSecondCourse] = command[1];

                    if (indexOfFirstCourse + 1 < schedule.Count && schedule[indexOfFirstCourse + 1] == $"{command[1]}-Exercise")
                    {
                        schedule.RemoveAt(indexOfFirstCourse + 1);
                        indexOfFirstCourse = schedule.IndexOf(command[1]);
                        schedule.Insert(indexOfFirstCourse + 1, $"{command[1]}-Exercise");
                    }
                    if (indexOfSecondCourse + 1 < schedule.Count && schedule[indexOfSecondCourse + 1] == $"{command[2]}-Exercise")
                    {
                        schedule.RemoveAt(indexOfSecondCourse + 1);
                        indexOfSecondCourse = schedule.IndexOf(command[2]);
                        schedule.Insert(indexOfSecondCourse + 1, $"{command[2]}-Exercise");
                    }

                }
                else if (command[0] == "Exercise")
                {
                    int indexOfCourse = schedule.IndexOf(command[1]);
                    if (schedule.Contains(command[1]) && !schedule.Contains($"{command[1]}-Exercise"))
                    {
                        schedule.Insert(indexOfCourse + 1, $"{command[1]}-Exercise");
                    }
                    else if (!schedule.Contains(command[1]))
                    {
                        schedule.Add(command[1]);
                        schedule.Add($"{command[1]}-Exercise");
                    }
                }

                command = Console.ReadLine().Split(":").ToArray();
            }


            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }

        }
    }
}


