using task2._1_sigma_;

int[] array1 = new int[] { 1, 2, 3 };
int[] array2 = new int[] { 11, 4, 17, 4 };
int[] array3 = new int[] { 31, 22, 90, 8, 83 };
int[] array4 = new int[] { 14, 25, 43 };
int[] array5 = new int[] { 37, 9, 6 };
int[] array6 = new int[] { 1 };

foreach (var item in ArrayHelper.ConcatArrays(array1, array2, array3, array4, array5, array6))
{
    Console.Write(item + " ");
}
