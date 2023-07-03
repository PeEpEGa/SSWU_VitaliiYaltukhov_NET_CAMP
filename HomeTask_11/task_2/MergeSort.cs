using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortTest
{
    internal static class MergeSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }
            int middle = array.Length / 2;
            int[] leftArr = new int[middle];
            int[] rightArr = new int[array.Length - middle];

            int l = 0;
            int r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (l < middle)
                {
                    leftArr[l++] = array[i];
                }
                else
                {
                    rightArr[r++] = array[i];
                }
            }
            Sort(leftArr);
            Sort(rightArr);
            Merge(array, leftArr, rightArr);
        }

        private static void Merge(int[] array, int[] leftArr, int[] rightArr)
        {
            int l = 0;
            int r = 0;
            int i = 0;
            while (l < leftArr.Length && r < rightArr.Length)
            {
                if (leftArr[l] < rightArr[r])
                {
                    array[i] = leftArr[l];
                    ++l;
                }
                else
                {
                    array[i] = rightArr[r];
                    ++r;
                }
                ++i;
            }
            while (l < leftArr.Length)
            {
                array[i] = leftArr[l];
                ++l;
                ++i;
            }

            while (r < rightArr.Length)
            {
                array[i] = rightArr[r];
                ++r;
                ++i;
            }
        }
    }
}
