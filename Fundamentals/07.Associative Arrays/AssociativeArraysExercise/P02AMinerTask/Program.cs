using System;
using System.Collections.Generic;

namespace P02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> miners = new Dictionary<string, double>();

            while (true)
            {
                string ruin = Console.ReadLine();
                if (ruin == "stop")
                {
                    break;
                }

                double quantity = double.Parse(Console.ReadLine());

                if (!miners.ContainsKey(ruin))
                {
                    miners.Add(ruin,quantity);
                }
                else
                {
                    miners[ruin] += quantity;
                }
            }

            foreach (var miner in miners)
            {
                Console.WriteLine($"{miner.Key} -> {miner.Value}");
            }
        }
    }
}
