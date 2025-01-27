using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double persons = int.Parse(Console.ReadLine());
            string type = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();

            double discount = 0;
            double sum = 0;

            switch (day)
            {
                case "friday":
                    switch (type)
                    {
                        case "students":
                            if (persons >= 30)
                            {
                                sum = persons * 8.45;
                                discount = sum * 0.15;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 8.45;
                            }
                            break;
                        default:
                            break;
                        case "business":
                            if (persons >= 100)
                            {
                                persons -= 10;
                                sum = persons * 10.9;
                            }
                            else
                            {
                                sum = persons * 10.9;
                            }
                            break;
                        case "regular":
                            if (persons >= 10 && persons <= 20)
                            {
                                sum = persons * 15;
                                discount = sum * 0.05;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 15;
                            }
                            break;
                    }
                    break;
                case "saturday":
                    switch (type)
                    {
                        case "students":
                            if (persons >= 30)
                            {
                                sum = persons * 9.8;
                                discount = sum * 0.15;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 9.8;
                            }
                            break;
                        default:
                            break;
                        case "business":
                            if (persons >= 100)
                            {
                                persons -= 10;
                                sum = persons * 15.6;
                            }
                            else
                            {
                                sum = persons * 15.6;
                            }
                            break;
                        case "regular":
                            if (persons >= 10 && persons <= 20)
                            {
                                sum = persons * 20;
                                discount = sum * 0.05;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 20;
                            }
                            break;
                    }
                    break;
                case "sunday":
                    switch (type)
                    {
                        case "students":
                            if (persons >= 30)
                            {
                                sum = persons * 10.46;
                                discount = sum * 0.15;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 10.46;
                            }
                            break;
                        default:
                            break;
                        case "business":
                            if (persons >= 100)
                            {
                                persons -= 10;
                                sum = persons * 16;
                            }
                            else
                            {
                                sum = persons * 16;
                            }
                            break;
                        case "regular":
                            if (persons >= 10 && persons <= 20)
                            {
                                sum = persons * 22.5;
                                discount = sum * 0.05;
                                sum -= discount;
                            }
                            else
                            {
                                sum = persons * 22.5;
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
