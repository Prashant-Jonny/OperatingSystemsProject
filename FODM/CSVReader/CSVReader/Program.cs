using System;
using System.IO;

namespace CSVReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var csvFileName = String.Empty;
            var outputFileName = String.Empty;

            var file = ReadCSV(csvFileName);
            var output = ConvertFileToReadableOutput(file);
            File.WriteAllText(outputFileName, output);
        }

        private static string ConvertFileToReadableOutput(string file)
        {
            var lines = file.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var output = string.Empty;
            foreach (var line in lines)
            {
                var attributes = line.Split(new char[]{','});
                foreach(var attribute in attributes)
                {
                    output = String.Format("{0}\t{1}", output, attribute);
                }
                output = String.Format("{0}\n", output);
            }

            return output;
        }

        private static string ReadCSV(string csvFileName)
        {
            var retVal = File.ReadAllText(csvFileName);
            return retVal;
        }
    }
}
