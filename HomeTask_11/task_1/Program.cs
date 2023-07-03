using TestQuickSort_;

int[] arr = { 19, 25, 37, 11, 3, 7, 8, 2, 6, -5, 4, 14, 44, 7, -1, 1, 0 };

//DefaultQuickSort quickSortVariation = new DefaultQuickSort();
//FirstElementQuickSort quickSortVariation = new FirstElementQuickSort();
MiddleQuickSort quickSortVariation = new MiddleQuickSort();

quickSortVariation.Sort(arr, 0, arr.Length - 1);
//quickSortVariation.Sort(arr, 0, arr.Length - 1, 3);
Console.WriteLine($"Sorted array with specified variation of index {quickSortVariation.GetType().Name}:");
foreach (var num in arr)
{
    Console.Write(num + " ");
}