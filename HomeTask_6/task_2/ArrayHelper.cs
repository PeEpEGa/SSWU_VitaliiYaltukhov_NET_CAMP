namespace task2._1_sigma_
{
    public static class ArrayHelper
    {
        public static IEnumerable<int> ConcatArrays(params int[][] arrays)
        {
            List<int> arr = new List<int>();
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    arr.Add(arrays[i][j]);
                }
            }
// Оригінально.
            while (arr.Count() != 0)
            {
                int element = arr.Min();
                yield return element;
                arr.Remove(element);
            }
        }
    }
}
