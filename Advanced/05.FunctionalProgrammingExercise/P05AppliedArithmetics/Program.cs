using System;
using System.Collections.Generic;
using System.Linq;

namespace P05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        var addedList = new List<int>();
                        nums.ForEach(x => addedList.Add(x+=1));
                        nums = addedList;
                        break;
                    case "multiply":
                        var multiList = new List<int>(); 
                            nums.ForEach(x => multiList.Add(x *= 2));
                        nums = multiList;
                        break;
                    case "subtract":
                        var subtractedList = new List<int>();
                        nums.ForEach(x => subtractedList.Add(x-=1));
                        nums = subtractedList;
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", nums));
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
