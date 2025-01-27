using System;

namespace P01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string[] days = new string[]
                {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            if (num >= 1 && num <= 7)
            {
                Console.WriteLine(days[num-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
