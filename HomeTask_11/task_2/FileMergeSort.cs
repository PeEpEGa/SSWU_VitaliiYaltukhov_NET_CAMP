using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortTest
{
    internal class FileMergeSort
    {
        public static void MergeTwoFiles(string outputFile, string firstFile, string secondFile)
        {
            using StreamWriter streamWriter = new StreamWriter(outputFile);
            using StreamReader firstPartReader = new StreamReader(firstFile);
            using StreamReader secondPartReader = new StreamReader(secondFile);

            int? firstPartElement = int.Parse(firstPartReader.ReadLine());
            int? secondPartElement = int.Parse(secondPartReader.ReadLine());

            while (firstPartElement != null || secondPartElement != null)
            {
                if (firstPartElement != null && (secondPartElement == null || firstPartElement <= secondPartElement))
                {
                    streamWriter.WriteLine(firstPartElement);
                    firstPartElement = ReadInteger(firstPartReader);
                }
                else
                {
                    streamWriter.WriteLine(secondPartElement);
                    secondPartElement = ReadInteger(secondPartReader);
                }
            }

            firstPartReader.Dispose();
            secondPartReader.Dispose();
            streamWriter.Dispose();

            File.Delete(firstFile);
            File.Delete(secondFile);
        }
        private static int? ReadInteger(StreamReader? reader)
        {
            if (reader != null)
            {
                string? line = reader.ReadLine();
                if (line != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        return number;
                    }
                    throw new InvalidDataException("Line consist of incorrect character");
                }
            }
            return null;
        }
            
        public static void SortArrayWith100Elements(string outputFile, string firstFile, string secondFile)
        {
            using StreamReader streamReader = new StreamReader(outputFile);

            int[] arr = new int[50];

            FileHelper.ReadChunkFromFileToArray(streamReader, arr, 50);
            MergeSort.Sort(arr);
            FileHelper.WriteChunkInFile(firstFile, arr);


            FileHelper.ReadChunkFromFileToArray(streamReader, arr, 50);
            MergeSort.Sort(arr);
            FileHelper.WriteChunkInFile(secondFile, arr);

            streamReader.Dispose();

            MergeTwoFiles(outputFile, firstFile, secondFile);
        }
    }
}
