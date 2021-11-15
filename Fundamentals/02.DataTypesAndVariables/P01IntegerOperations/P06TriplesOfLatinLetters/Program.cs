using System;

namespace P06TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int first = 0; first < n; first++)
            {
                char firstChar = (char)('a' + first);
                for (int second = 0; second < n; second++)
                {
                    char secondChar = (char)('a' + second);
                    for (int third = 0; third < n; third++)
                    {
                        char thirdChar = (char)('a' + third);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }

        }
    }
}
