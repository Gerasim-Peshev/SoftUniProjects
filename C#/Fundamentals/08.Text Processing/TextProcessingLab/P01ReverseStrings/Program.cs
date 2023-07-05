using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace P01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string reversed = "";
            List<string> strings = new List<string>();
            while (command != "end")
            {
                for (int i = command.Length-1; i >= 0; i--)
                {
                    reversed += command[i];
                }
                strings.Add($"{command} = {reversed}");
                reversed = "";
                command = Console.ReadLine();
            }

            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
