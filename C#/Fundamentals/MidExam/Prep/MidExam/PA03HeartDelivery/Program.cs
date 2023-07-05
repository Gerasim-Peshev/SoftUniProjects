using System;
using System.Collections.Generic;
using System.Linq;

namespace PA03HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var command = Console.ReadLine().Split().ToArray();
            int currHouseIndex = 0;

            while (command[0] != "Love!")
            {
                string action = command[0];
                int lenght = int.Parse(command[1]);


                if (currHouseIndex + lenght >= neighborhood.Count)
                {
                    currHouseIndex = 0;
                }
                else
                {
                    currHouseIndex += lenght;
                    //currHouseIndex = currHouseIndex + lenght
                }

                neighborhood[currHouseIndex] -= 2;
                if (neighborhood[currHouseIndex] == 0)
                {
                    Console.WriteLine($"Place {currHouseIndex} has Valentine's day.");
                }
                else if (neighborhood[currHouseIndex] < 0)
                {
                    Console.WriteLine($"Place {currHouseIndex} already had Valentine's day.");
                }

                command = Console.ReadLine().Split().ToArray();
            }

            int count = 0;
            for (int i = 0; i < neighborhood.Count; i++)
            {
                if (neighborhood[i] > 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"Cupid's last position was {currHouseIndex}.");
            if (count == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}
