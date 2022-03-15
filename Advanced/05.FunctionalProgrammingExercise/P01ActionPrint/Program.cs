using System;
using System.Linq;
using System.Threading.Channels;

namespace P01ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = s => Console.WriteLine(s);

            Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(printNames);
        }
    }
}
