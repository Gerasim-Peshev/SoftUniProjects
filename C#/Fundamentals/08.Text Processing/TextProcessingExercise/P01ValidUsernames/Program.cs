using System;
using System.Collections.Generic;
using System.Linq;

namespace P01ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ").ToArray();
            

            foreach (var username in usernames)
            {
                if (username.Length > 3 && username.Length <= 16)
                {
                    bool check = true;
                    foreach (char c in username)
                    {
                        if (!((c >= (char)65 && c <= (char)90) || (c >= (char)97 && c <= (char)122) || c == (char)95 || c == (char)45 || (c >= (char)48 && c <= (char)57)))
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check)
                    {
                        Console.WriteLine(username);
                    }
                }
            }

            
        }
    }
}
