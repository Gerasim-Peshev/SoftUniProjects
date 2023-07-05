using System;

namespace PV01SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int totalAnswers = 0;

            for (int i = 0; i < 3; i++)
            {
                totalAnswers += int.Parse(Console.ReadLine());
            }

            int questions = int.Parse(Console.ReadLine());

            int countHour = 0;
            int countRests = 0;
            while (questions > 0)
            {
                questions -= totalAnswers;
                countHour++;

                if (countHour % 4 == 0)
                {
                    countHour++;
                }

                //questions -= totalAnswers;

                //if (questions <= 0)
                //{
                //    countHour++;
                //    break;
                //}

                //countHour++;
                //if (countHour % 3 == 0)
                //{
                //    countRests++;
                //}


            }

            Console.WriteLine($"Time needed: {countHour }h.");
                                                    //+ countRests 
        }
    }
}
