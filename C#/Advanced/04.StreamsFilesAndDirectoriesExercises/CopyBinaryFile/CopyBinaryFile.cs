using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fileStreamReader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream fileStreamWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] bites = new byte[512];

            while (true)
            {
                int curBites = fileStreamReader.Read(bites, 0, bites.Length);
                if (curBites == 0)
                {
                    break;
                }

                fileStreamWriter.Write(bites, 0, bites.Length);
            }
        }
    }
}
