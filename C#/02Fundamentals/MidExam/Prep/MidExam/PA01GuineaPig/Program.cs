using System;

namespace PA01GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            double quantityOfFood = double.Parse(Console.ReadLine()) * 1000;
            double quantityOfHay = double.Parse(Console.ReadLine()) * 1000;
            double quantityOfCover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            int curDay = 1;

            for (int i = 0; i < 30; i++)
            {
                
                    quantityOfFood -= 300;
                
                

                if (curDay % 2 == 0)
                {
                    quantityOfHay -= quantityOfFood * 0.05;
                    //quantityOfHay = quantityOfHay - (quantityOfFood * 0.05)
                }
                

                if (curDay % 3 == 0)
                {
                    quantityOfCover -= (weight / 3);
                }

                if (quantityOfFood <= 0 || quantityOfHay <= 0 || quantityOfCover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

                curDay++;
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityOfFood/1000:f2}, Hay: {quantityOfHay/1000:f2}, Cover: {quantityOfCover/1000:f2}.");
        }
    }
}
