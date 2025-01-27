using System;

namespace _04BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            mins += 30;

            if (mins > 60)
            {
                hour++;
                mins -= 60;
            }
            else if (mins == 60)
            {
                hour++;
                mins = 0;
            }

            if (hour == 24)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{mins:d2}");
        }
    }
}
