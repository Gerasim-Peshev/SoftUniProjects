using System;

namespace PA01ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumPrice = 0;
            double tax = 0;

            string command = Console.ReadLine();

            while (command != "regular" && command != "special")
            {
                double num = double.Parse(command);

                if (num <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    sumPrice += num;
                }

                command = Console.ReadLine();
            }

            tax = sumPrice * 0.2;

            if (sumPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else if (command == "special")
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sumPrice:f2}$");
                Console.WriteLine($"Taxes: {tax:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {(sumPrice + tax) - ((sumPrice + tax) * 0.1):f2}$");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sumPrice:f2}$");
                Console.WriteLine($"Taxes: {tax:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {sumPrice + tax:f2}$");
            }
        }
    }
}