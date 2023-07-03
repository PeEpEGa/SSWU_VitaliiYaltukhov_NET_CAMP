using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuickSort_
{
    public class DefaultQuickSort
    {
        private static Random _random = new Random();

        public void Sort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            try
            {
                if (low < high)
                {
                    int pivotIndex = Partition(array, low, high);
                    Sort(array, low, pivotIndex);
                    Sort(array, pivotIndex + 1, high);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Sort with defined index
        public void Sort<T>(T[] array, int low, int high, int pivotInd) where T : IComparable<T>
        {
            try
            {
                if (low < high)
                {
                    int pivotIndex = Partition(array, low, high, pivotInd);

                    Sort(array, low, pivotIndex, low);
                    Sort(array, pivotIndex + 1, high, pivotIndex + 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Lomuto partition
        private int Partition<T>(T[] array, int low, int high, int pivotIndex) where T : IComparable<T>
        {
            Swap(array, pivotIndex, high);
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j].CompareTo(pivot) < 0)
                {
                    Swap(array, ++i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        //Hoare partition
        protected virtual int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            int randomIndex = _random.Next(low, high + 1);

            T pivot = array[randomIndex];

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

        protected void Swap<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
