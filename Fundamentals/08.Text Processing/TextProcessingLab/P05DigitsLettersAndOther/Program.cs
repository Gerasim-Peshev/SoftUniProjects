using System;

namespace P05DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string digits = "";
            string chars = "";
            string other = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] >= (char)48 && word[i] <= (char)57)
                {
                    digits += word[i];
                }
                else if ((word[i] >= (char)65 && word[i] <= (char)90) || (word[i] >= (char)97 && word[i] <= (char)122))
                {
                    chars += word[i];
                }
                else
                {
                    other += word[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(chars);
            Console.WriteLine(other);
        }
    }
}
