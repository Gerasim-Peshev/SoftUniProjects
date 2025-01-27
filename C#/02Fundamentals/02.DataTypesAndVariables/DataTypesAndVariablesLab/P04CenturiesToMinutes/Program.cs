using System;

namespace P04CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            double cent = int.Parse(Console.ReadLine());

            double years = Math.Round(cent * 100);
            double days = Math.Round(years * 365.2422);
            double hours = Math.Round(days * 24);
            double mins = Math.Round(hours * 60);

            Console.WriteLine($"{cent} centuries = {years} years = {days} days = {hours} hours = {mins} minutes");
        }
    }
}
