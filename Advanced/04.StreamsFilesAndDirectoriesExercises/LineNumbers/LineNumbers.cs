using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var lines = File.ReadAllLines(inputFilePath);

            var sb = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                int counterLetters = line.Count(x => char.IsLetter(x));
                int countPunkst = line.Count(x => char.IsPunctuation(x));

                sb.Add($"Line {i + 1}: {line} ({counterLetters})({countPunkst})");
            }

            File.WriteAllLines(outputFilePath,sb);
        }
    }
}

