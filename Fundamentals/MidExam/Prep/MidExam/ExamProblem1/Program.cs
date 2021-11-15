using System;
using System.Threading;

namespace ExamProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double totalEnergy = double.Parse(Console.ReadLine());
            double waterForEach = double.Parse(Console.ReadLine());
            double foodForEach = double.Parse(Console.ReadLine());

            double losingEnergy = double.Parse(Console.ReadLine());

            double water = waterForEach * days * players;
            double food = foodForEach * days * players;
            int countDays = 0;
            for (int i = 0; i < days; i++)
            {
                totalEnergy -= losingEnergy;
                if (totalEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");
                    return;
                }

                countDays++;
                if (countDays % 2 == 0)
                {
                    totalEnergy += totalEnergy * 0.05;
                    water -= water * 0.3;
                }

                if (countDays % 3 == 0)
                {
                    food -= food / players;
                    totalEnergy += totalEnergy * 0.1;
                }

                if (i != days - 1)
                {
                    losingEnergy = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {totalEnergy:f2} energy!");
        }
    }
}
