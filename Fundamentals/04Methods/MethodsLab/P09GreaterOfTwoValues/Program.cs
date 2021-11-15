using System;

namespace P09GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {

            //88/100

            string type = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Max(type, first, second);

        }

        static void Max(string type, string first, string second)
        {
            switch (type)
            {
                case "int":
                    Console.WriteLine(int.Parse(first) >= int.Parse(second) ? int.Parse(first) : int.Parse(second));
                    break;
                case "char":
                    Console.WriteLine(first.CompareTo(second) >= 0 ? first : second);
                    break;
                case "string":
                    Console.WriteLine(first.CompareTo(second) >= 0 ? first : second);
                    break;
            }
        }
    }
}
