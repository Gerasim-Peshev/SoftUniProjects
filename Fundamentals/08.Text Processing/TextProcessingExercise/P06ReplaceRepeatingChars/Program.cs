using System;
using System.Text;

namespace P06ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string command = Console.ReadLine();


            for (int i = 0; i < command.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(command[i]);
                }
                else if (command[i] != command[i - 1])
                {
                    sb.Append(command[i]);
                }
            }


            Console.WriteLine(sb);
        }
    }
}
