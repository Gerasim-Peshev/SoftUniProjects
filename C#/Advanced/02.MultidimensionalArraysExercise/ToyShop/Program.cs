using System;
using System.Net.Http.Headers;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfHoliday = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int mechosCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int milioniKamioni = int.Parse(Console.ReadLine());

            double sum = puzzleCount * 2.6 + dollsCount * 3 + mechosCount * 4.1 + minionsCount * 8.2 + milioniKamioni * 2;
            if (puzzleCount+dollsCount+mechosCount+minionsCount+milioniKamioni >= 50) sum -= sum * 0.25;
            sum -= sum * 0.1;

            Console.WriteLine(priceOfHoliday <= sum ? $"Yes! {sum-priceOfHoliday:f2} lv left." : $"Not enough money! {priceOfHoliday-sum:f2} lv needed.");
        }
    }
}
