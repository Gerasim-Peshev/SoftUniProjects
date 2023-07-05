using System;

namespace P11PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = double.Parse(Console.ReadLine());

            double price = size * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;

            Console.WriteLine($"The final price is: {(size * 7.61) - ((size * 7.61) * 0.18)} lv.");
            Console.WriteLine($"The discount is: {(size * 7.61) * 0.18} lv.");

            //Console.WriteLine($"The final price is: {finalPrice}");
            //Console.WriteLine($"The discount is: {discount}");
        }
    }
}
