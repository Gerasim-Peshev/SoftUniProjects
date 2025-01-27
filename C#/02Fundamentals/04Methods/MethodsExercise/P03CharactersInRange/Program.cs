using System;

namespace P03CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            Range(first, second);
        }

        static void Range(char first, char second)
        {
            if (first > second)
            {
                for (int i = second + 1; i < first; i++)
                {
                    Console.Write($"{(char)(i)} ");
                }
            }
            else
            {
                for (int i = first + 1; i < second; i++)
                {
                    Console.Write($"{(char)(i)} ");
                }
            }
        }
    }
}
