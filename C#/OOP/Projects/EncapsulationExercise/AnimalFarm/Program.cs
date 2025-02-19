﻿namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
            }
            catch (Exception wx)
            {
                Console.WriteLine(wx.Message);
                return;
            }

        }
    }
}
