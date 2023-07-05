using System;
using System.Linq;
using System.Collections.Generic;

namespace P07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coin = Console.ReadLine();

            double money = 0;
            double Nuts = 2;
            double Water = 0.7;
            double Crisps = 1.5;
            double Soda = 0.8;
            double Coke = 1;

            while (coin != "Start")
            {
                if (double.Parse(coin) == 0.1 || double.Parse(coin) == 0.2 || double.Parse(coin) == 0.5 || double.Parse(coin) == 1 || double.Parse(coin) == 2)
                {
                    money += double.Parse(coin);
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                coin = Console.ReadLine();

            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        if (money - Nuts < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            money -= Nuts;
                            Console.WriteLine("Purchased nuts");
                        }
                        break;
                    case "Water":
                        if (money - Water < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            money -= Water;
                            Console.WriteLine("Purchased water");
                        }
                        break;
                    case "Crisps":
                        if (money - Crisps < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            money -= Crisps;
                            Console.WriteLine("Purchased crisps");
                        }
                        break;
                    case "Soda":
                        if (money - Soda < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            money -= Soda;
                            Console.WriteLine("Purchased soda");
                        }
                        break;
                    case "Coke":
                        if (money - Coke < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            money -= Coke;
                            Console.WriteLine("Purchased coke");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}

            //while (product != "End")
            //{


            //    if (product == "Nuts")
            //    {
            //        money -= Nuts;

            //    }
            //    else if (product == "Water")
            //    {
            //        money -= Water;

            //    }
            //    else if (product == "Crisps")
            //    {
            //        money -= Crisps;

            //    }
            //    else if (product == "Soda")
            //    {
            //        money -= Soda;

            //    }
            //    else if (product == "Coke")
            //    {
            //        money -= Coke;

            //    }

            //    if (money <= 0)
            //    {
            //        Console.WriteLine("Sorry, not enough money");
            //        Console.WriteLine($"Change: {money:f2}");
            //        return;
            //    }
            //    else
            //    {
            //        if (product == "Nuts")
            //        {

            //            Console.WriteLine("Purchased nuts");
            //        }
            //        else if (product == "Water")
            //        {

            //            Console.WriteLine("Purchased water");
            //        }
            //        else if (product == "Crisps")
            //        {

            //            Console.WriteLine("Purchased crisps");
            //        }
            //        else if (product == "Soda")
            //        {

            //            Console.WriteLine("Purchased soda");
            //        }
            //        else if (product == "Coke")
            //        {

            //            Console.WriteLine("Purchased coke");
            //        }
            //    }

                
            //    product = Console.ReadLine();

            //}