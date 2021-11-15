using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace P10LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugsField = new int[fieldSize];

            string[] occupaidIndexes = Console.ReadLine().Split();
            foreach (var t in occupaidIndexes)
            {
                int currentindex = int.Parse(t);
                if (currentindex >= 0 && currentindex < fieldSize)
                {
                    ladyBugsField[currentindex] = 1;
                }
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                int cuurIndex = int.Parse(commands[0]);
                bool isFirst = true;
                while (cuurIndex >= 0 && cuurIndex < fieldSize && ladyBugsField[cuurIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugsField[cuurIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLenght = int.Parse(commands[2]);

                    if (direction == "left")
                    {
                        cuurIndex -= flightLenght;
                        if (cuurIndex >= 0 && cuurIndex < fieldSize)
                        {
                            if (ladyBugsField[cuurIndex] == 0)
                            {
                                ladyBugsField[cuurIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cuurIndex += flightLenght;
                        if (cuurIndex >= 0 && cuurIndex < fieldSize)
                        {
                            if (ladyBugsField[cuurIndex] == 0)
                            {
                                ladyBugsField[cuurIndex] = 1;
                                break;
                            }
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",ladyBugsField));
        }
    }
}
