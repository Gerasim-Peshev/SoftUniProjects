using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int count = 0;
            string input = Console.ReadLine();
            while (input != password)
            {
                count++;
                if (count > 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }
            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
