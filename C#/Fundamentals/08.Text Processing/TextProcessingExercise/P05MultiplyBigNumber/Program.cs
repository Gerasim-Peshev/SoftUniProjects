using System;
using System.Text;

namespace P05MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string first = Console.ReadLine();
            int second = int.Parse(Console.ReadLine());

            if (second == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int reminder = 0;
            for (int i = first.Length-1; i >= 0; i--)
            {
                int product = int.Parse(first[i].ToString()) * second + reminder;
                int redy = product % 10;
                reminder = product / 10;
                sb.Insert(0, redy);
            }

            if (reminder > 0)
            {
                sb.Insert(0, reminder);
            }

            Console.WriteLine(sb);
        }
    }
}
