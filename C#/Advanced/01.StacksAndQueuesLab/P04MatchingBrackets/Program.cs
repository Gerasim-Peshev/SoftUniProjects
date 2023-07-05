using System;
using System.Collections.Generic;

namespace P04MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> brackets = new Stack<int>();

            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = brackets.Pop();
                    var endIndex = i;
                    Console.WriteLine(input.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}
