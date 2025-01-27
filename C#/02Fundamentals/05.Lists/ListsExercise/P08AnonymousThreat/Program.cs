using System;
using System.Collections.Generic;
using System.Linq;

namespace P08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            //doesnt work already

            List<string> dataList = Console.ReadLine().Split().ToList();

            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "3:1")
            {
                var s = "";
                if (command[0] == "merge")
                {
                    for (int i = int.Parse(command[1]); i <= int.Parse(command[2]); i++)
                    {
                        s = s + dataList[i];
                    }

                }
                int index = int.Parse(command[1]);
                dataList[index] = s;
                dataList.RemoveRange(int.Parse(command[1] + 1), int.Parse(command[2]));

                command = Console.ReadLine().Split().ToList();
            }

            for (int i = 0; i < dataList.Count; i++)
            {
                Console.Write($"{dataList[i]} ");
            }
        }
    }
}
