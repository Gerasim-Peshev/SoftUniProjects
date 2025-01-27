using System;

namespace P06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            PrintMiddle(word);
        }

        static void PrintMiddle(string word)
        {
            if (word.Length % 2 != 0)
            {
                Console.WriteLine(word[word.Length / 2]);
            }
            else
            {
                Console.Write(word[(word.Length / 2) - 1]);
                Console.WriteLine(word[word.Length / 2]);
            }
        }
    }
}
