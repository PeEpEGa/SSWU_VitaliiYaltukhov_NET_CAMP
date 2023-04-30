using task2._1_sigma_;

Console.WriteLine("ZigzagMatrix1");
ZigzagMatrix matrix = new ZigzagMatrix(5);
foreach (var item in matrix)
{
    Console.Write(item + " ");
}

Console.WriteLine("\n\nZigzagMatrix2");
ZigzagMatrix matrix1 = new ZigzagMatrix(new int[3, 3] { { 1, 4, 6 }, { 2, 5, 7 }, { 9, 4, 2 } });
foreach (var item in matrix1)
{
    Console.Write(item + " ");
}