using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortTest
{
    internal static class Generator
    {
        public static void GenerateValues(string fileName, int amount, int min, int max)
        {
            if(min < 0 || max <= min)
            {
                return;
            }

            using StreamWriter sw = new StreamWriter(fileName);
            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {
                sw.WriteLine($"{random.Next(min, max)}");
            }
        }
    }
}