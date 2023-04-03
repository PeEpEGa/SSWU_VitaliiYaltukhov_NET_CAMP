namespace task3;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var cube = new int[4, 4, 4] {
                                  {
                                    { 1, 1, 1, 0 },
                                    { 1, 1, 1, 1 },
                                    { 1, 0, 1, 1 },
                                    { 1, 1, 1, 1 }
                                  },

                                  {
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 0, 1 },
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 1, 1 }
                                  },

                                  {
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 0, 1 },
                                    { 1, 1, 1, 1 }
                                  },

                                  {
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 1, 0 },
                                    { 1, 1, 1, 1 },
                                    { 1, 1, 1, 1 }
                                  },

};

        CubeShape cube1 = new CubeShape(cube);

        Console.WriteLine("Cube: \n" + cube1.ToString());

        List<((int col, int row), (int col, int row))> result = cube1.CheckDFSForEveryTopVertex(cube1);
        Console.WriteLine("Result:");
        foreach (var item in result)
        {
            Console.WriteLine($"Result: Start column: {item.Item1.col}. Start row: {item.Item1.row}.  Finish column: {item.Item2.col}. Finish row: {item.Item2.row}.");
        }
    }
}