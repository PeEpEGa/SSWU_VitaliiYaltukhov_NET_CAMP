using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuickSort_
{
    public class MiddleQuickSort : DefaultQuickSort
    {
        protected override int Partition<T>(T[] array, int low, int high)
        {
            int middleIndex = (high + low) / 2;

            T pivot = array[middleIndex];

            int i = low - 1;
            int j = high + 1;
            while (true)
            {
                do
                {
                    ++i;
                } while (array[i].CompareTo(pivot) < 0);
                do
                {
                    --j;
                } while (array[j].CompareTo(pivot) > 0);
                if (i >= j)
                {
                    return j;
                }
                Swap(array, i, j);
            }
        }
    }
}
