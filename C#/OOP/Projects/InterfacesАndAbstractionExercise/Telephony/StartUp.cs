using System;
using System.Linq;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                bool isNumber = true;
                foreach (var n in number)
                {
                    if (!Char.IsDigit(n))
                    {
                        isNumber = false;
                        break;
                    }
                }

                if (isNumber)
                {
                    if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        smartphone.Call(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in sites)
            {
                bool isSite = true;
                foreach (var s in site)
                {
                    if (Char.IsDigit(s))
                    {
                        isSite = false;
                        break;
                    }
                }

                if (isSite)
                {
                    smartphone.Browse(site);
                }
                else
                {
                    Console.WriteLine($"Invalid URL!");
                }
            }
        }
    }
}
