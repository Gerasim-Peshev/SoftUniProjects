using System;

namespace P02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            Console.WriteLine(FindVowels(word));
        }

        static int FindVowels(string word)
        {
            int lenght = word.Length;
            int count = 0;

            for (int i = 0; i < lenght; i++)
            {
                char letter = word[i];
                if (letter == 97 || letter == 111 || letter == 117 || letter == 101 || letter == 105)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
