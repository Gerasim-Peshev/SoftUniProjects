using System;

namespace P09Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double studentCount = double.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            //double disStu = Math.Ceiling(studentCount * 0.1);
            double lightsabersSum = Math.Ceiling(lightsaberPrice * Math.Ceiling(studentCount * 1.1));

            double robesSum = robesPrice * studentCount;

            double beltSum = (studentCount - Math.Floor(studentCount / 6)) * beltPrice;

            double sum = lightsabersSum + robesSum + beltSum;

            Console.WriteLine(money - sum >= 0 ? $"The money is enough - it would cost {sum:f2}lv." : $"John will need {(money - sum) * -1:f2}lv more.");

            //if (money - sum >= 0)
            //{
            //    Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            //}
            //else
            //{
            //    Console.WriteLine($"John will need {(money - sum) * -1:f2}lv more.");
            //}
        }
    }
}
