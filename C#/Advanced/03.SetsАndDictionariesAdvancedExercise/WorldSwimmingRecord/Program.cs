using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldRecord = double.Parse(Console.ReadLine());
            var meters = double.Parse(Console.ReadLine());
            var timeForMeter = double.Parse(Console.ReadLine());

            double hisTime = meters * timeForMeter + Math.Floor(meters / 15) * 12.5;
      

            Console.WriteLine(hisTime >= oldRecord ? $"No, he failed! He was {Math.Abs(oldRecord - hisTime):f2} seconds slower." : $"Yes, he succeeded! The new world record is {Math.Abs(hisTime):f2} seconds.");
        }
    }
}
