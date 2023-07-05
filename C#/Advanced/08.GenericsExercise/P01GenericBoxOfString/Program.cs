using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace P01GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameAndAddress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var firstTuple =
                new MyCustomTuple<string, string, string>($"{nameAndAddress[0]} {nameAndAddress[1]}", string.Join(" ", nameAndAddress[2], nameAndAddress.Length - 1), nameAndAddress[nameAndAddress.Length - 1]);

            var nameAndLitresOfBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var secondTuple = new MyCustomTuple<string, int, bool>(nameAndLitresOfBeer[0], int.Parse(nameAndLitresOfBeer[1]), nameAndLitresOfBeer[2] == "drunk" ? true : false);

            var intAndDouble = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var thirdTuple = new MyCustomTuple<string, double, string>(intAndDouble[0], double.Parse(intAndDouble[1]),intAndDouble[2]);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
