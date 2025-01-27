using System;

namespace P10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double lostGames = double.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double diplayPrice = double.Parse(Console.ReadLine());


            int headCount = 0;
            int mouseCount = 0;
            int keyCount = 0;
            int disCount = 0;
            int count = 0;
            

            for (int i = 0; i < lostGames; i++)
            {
                count++;
                if (count % 2 == 0)
                {
                    headCount++;
                }
                if (count % 3 == 0)
                {
                    mouseCount++;
                }
                if (count % 6 == 0)
                {
                    keyCount++;
                }
                if (count % 12 == 0)
                {
                    disCount++;
                }
            }


            //for (int i = 0; i < keyCount; i++)
            //{
            //    count++;
            //    if (count % 2 == 0)
            //    {
            //        disCount++;
            //    }
            //}

            double headsetTrash = headCount * headsetPrice;
            double mouseTrash = mouseCount * mousePrice;
            double keyboardTrash = keyCount * keyboardPrice;
            double displayTrash = disCount * diplayPrice;
            Console.WriteLine($"Rage expenses: {headsetTrash + mouseTrash + keyboardTrash + displayTrash:f2} lv.");
        }
    }
}
