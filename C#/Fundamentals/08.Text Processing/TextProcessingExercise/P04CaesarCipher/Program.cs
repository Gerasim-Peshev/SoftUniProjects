using System;
using System.Text;

namespace P04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char c in command)
            {
                sb.Append((char)(c + 3));
            }

            Console.WriteLine(sb);
        }
    }
}
