using System;
using System.Linq;

namespace P09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLenght = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int[] DNA = new int[sequenceLenght];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaSamples = 0;
            int dnaStartIndex = 0;
            int dnaEndIndex = 0;
            int sample = 0;
            while (input != "Clone them!")
            {
                sample++;
                int[] currDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                       .ToArray();
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDnaSum = 0;
                bool isCurrDnaBetter = false;

                int count = 0;
                for (int i = 0; i < currDna.Length; i++)
                {
                    if (currDna[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (currCount < count)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }

                currStartIndex = currEndIndex - currCount + 1;
                currDnaSum = currDna.Sum();

                if (currCount > dnaCount)
                {
                    isCurrDnaBetter = true;
                }
                else if (currCount == dnaCount)
                {
                    if (currStartIndex < dnaStartIndex)
                    {
                        isCurrDnaBetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if (currDnaSum > dnaSum)
                        {
                            isCurrDnaBetter = true;
                        }
                    }
                }

                if (isCurrDnaBetter)
                {
                    DNA = currDna;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
