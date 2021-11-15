using System;
using System.Linq;

namespace P03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split("\\").ToArray();

            string[] words = command[command.Length - 1].Split(".").ToArray();

            string name = words[0];
            string extension = words[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
