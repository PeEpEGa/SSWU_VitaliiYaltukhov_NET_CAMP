using task2._1_sigma_;

Console.WriteLine("Unique words:");
foreach (var item in StringHelper.FindUniqueWords("   pizza  fd       \n q3dfw3 fe  q3fdfw3  fwef   fwef pizza  pizza123 pizza ug"))
{
    Console.WriteLine(item);
}