using System;

namespace P09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                bool isintegerPalindrom = ReturnIsNumberPalindrom(input);
                Console.WriteLine(isintegerPalindrom.ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        static bool ReturnIsNumberPalindrom(string input)
        {
            int number = int.Parse(input);
            if (number >= 0 && number <= 9)
            {
                return true;
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i]==input[input.Length-1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
