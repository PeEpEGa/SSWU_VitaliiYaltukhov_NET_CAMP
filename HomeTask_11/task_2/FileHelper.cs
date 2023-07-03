using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortTest
{
    internal class FileHelper
    {
        public static void ReadChunkFromFileToArray(StreamReader streamReader, int[] arr, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                arr[i] = int.Parse(streamReader.ReadLine());
            }
        }
        public static void WriteChunkInFile(string path, int[] arr)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            for (int i = 0; i < arr.Length; i++)
            {
                streamWriter.WriteLine(arr[i]);
            }

            streamWriter.Dispose();
        }

        public static int GetFileLength(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                int i = 0;
                while (r.ReadLine() != null) 
                {
                    i++;
                }
                return i;
            }
        }
    }
}