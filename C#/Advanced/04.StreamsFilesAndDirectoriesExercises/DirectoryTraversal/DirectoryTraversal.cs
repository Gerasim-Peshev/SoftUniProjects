using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] directories = Directory.GetFiles(inputFolderPath, "*");

            var fileInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var directory in directories)
            {
                string fullname = Path.GetFileName(directory);
                string extantion = Path.GetExtension(directory);
                double size = new FileInfo(directory).Length;

                if (!fileInfo.ContainsKey(extantion))
                {
                    fileInfo.Add(extantion,new Dictionary<string, double>());
                }

                fileInfo[extantion].Add(fullname, size);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var file in fileInfo.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                sb.AppendLine(file.Key);
                foreach (var c in file.Value.OrderBy(x=>x.Value))
                {
                    sb.AppendLine($"--{c.Key} - {c.Value / 1024:f3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllText(path, textContent);
        }

    }
}
