using System;
using System.Linq;

namespace P02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ").ToArray();
            int sum = GetSum(command[0], command[1]);
            Console.WriteLine(sum);

        }

        public static int GetSum(string wordOne, string wordTwo)
        {
            int sum = 0;

            int min = Math.Min(wordOne.Length, wordTwo.Length);

            int longest = wordOne.Length > wordTwo.Length ? wordOne.Length : wordTwo.Length;
            string longestWord = wordOne.Length > wordTwo.Length ? wordOne : wordTwo;

            for (int i = 0; i < min; i++)
            {
                sum += wordOne[i] * wordTwo[i];
            }

            for (int i = min; i < longest; i++)
            {
                sum += longestWord[i];
            }

            return sum;
        }
    }
}
