using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int count = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        string words = ReplaceSymbols(line);
                        sb.AppendLine(words);
                    }

                    line = reader.ReadLine();
                    count++;
                }
            }

            return sb.ToString();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            char[] signs = new[] { ' ', ',' };
            string sentence = string.Join(" ", replacedSymbols.Split().ToArray().Reverse());
            return sentence;
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbols = new[] { '-', ',', '.', '!', '?' };
            foreach (var symbol in symbols)
            {
                line = line.Replace(symbol, '@');
            }

            return ReverseWords(line);
        }
    }

}
