using System;
using System.Collections.Generic;
using System.Linq;

namespace P06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            int value = firstDeck.Count > secondDeck.Count ? secondDeck.Count : firstDeck.Count;


            //for cycle works as while

            for (int i = 0; i < value; i++)
            {
                if (firstDeck[i] > secondDeck[i])
                {
                    int ading = secondDeck[i];
                    int firstIndex = firstDeck[i];

                    secondDeck.RemoveAt(i);
                    firstDeck.RemoveAt(i);

                    firstDeck.Add(ading);
                    firstDeck.Add(firstIndex);

                    value = firstDeck.Count > secondDeck.Count ? secondDeck.Count : firstDeck.Count;
                    i = -1;
                }
                else if (secondDeck[i] > firstDeck[i])
                {
                    int ading = firstDeck[i];
                    int firstIndex = secondDeck[i];

                    firstDeck.RemoveAt(i);
                    secondDeck.RemoveAt(i);

                    secondDeck.Add(ading);
                    secondDeck.Add(firstIndex);

                    value = firstDeck.Count > secondDeck.Count ? secondDeck.Count : firstDeck.Count;
                    i = -1;
                }
                else if (firstDeck[i] == secondDeck[i])
                {
                    firstDeck.RemoveAt(i);
                    secondDeck.RemoveAt(i);

                    value = firstDeck.Count > secondDeck.Count ? secondDeck.Count : firstDeck.Count;
                    i = -1;
                }
            }

            if (firstDeck.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
        }
    }
}
