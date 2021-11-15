using System;
using System.Linq;
using System.Text;

namespace P05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine());

            int[] arr = sb.ToString().Split(' ').Select(int.Parse).ToArray();

            int index = arr.Length - 1;

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > arr[index])
                {
                    index--;
                    arr[index] = arr[i];
                }
            }

            sb.Clear();

            for (int i = index; i < arr.Length; i++)
            {
                sb.Append($"{arr[i]} ");
            }


            Console.WriteLine(sb.ToString());






            //int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            //int[] end = new int[numbers.Length + 1];
            //end[end.Length - 1] = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int num = numbers[i];
            //    bool check = false;

            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (num >= numbers[j])
            //        {
            //            check = true;
            //        }
            //        else
            //        {
            //            check = false;
            //        }

            //    }

            //    if (check == true)
            //    {
            //        end[i] = num;
            //    }
            //}



            //for (int i = 0; i < end.Length; i++)
            //{
            //    if (end[i] != 0)
            //    {
            //        Console.Write(end[i] + " ");
            //    }
            //}
        }
    }
}
