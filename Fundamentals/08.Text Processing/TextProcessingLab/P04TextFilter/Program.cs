using System;
using System.Linq;

namespace P04TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ").ToArray();

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                while (text.IndexOf(bannedWords[i]) >= 0)
                {
                    text = text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
