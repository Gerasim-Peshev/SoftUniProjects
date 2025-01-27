using System;
using System.Collections.Generic;
using System.Linq;

namespace PA02TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] liftCabine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < liftCabine.Length; i++)
            {
                while (liftCabine[i] != 4 && people != 0)
                {
                    liftCabine[i]++;
                    people--;
                }
            }

            bool check = false;
            bool full = false;
            int count = 0;
            for (int u = 0; u < liftCabine.Length; u++)
            {
                if (liftCabine[u] < 4)
                {
                    check = true;
                    break;
                }

                if (liftCabine[u] == 4)
                {
                    count++;
                }
            }

            if (count == 4)
            {
                full = true;
            }

            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", liftCabine));
            }
            else if (people < liftCabine.Length * 4 && liftCabine.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", liftCabine));
            }
            else if (liftCabine.All(w => w == 4) && people == 0)
            {
                Console.WriteLine(string.Join(" ", liftCabine));
            }

            //if (check)
            //{
            //    Console.WriteLine("The lift has empty spots!");
            //    Console.WriteLine(string.Join(" ", liftCabine));
            //}
            //else if (full)
            //{
            //    Console.WriteLine(string.Join(" ", liftCabine));
            //}
            //else
            //{
            //    Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            //    Console.WriteLine(string.Join(" ", liftCabine));
            //}
        }
    }
}