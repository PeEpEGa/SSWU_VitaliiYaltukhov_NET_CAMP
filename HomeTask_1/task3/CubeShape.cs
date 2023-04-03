using System.Text;
namespace task3;
//namespace task3;

public class CubeShape
{
	public int[,,] Cube { get; set; }
	public int Size { get; set; }

    public CubeShape(int size)
	{
		Size = size;
		Cube = new int[size, size, size];
	}
	public CubeShape(int[,,] cube)
	{
		Cube = cube;
        Size = Cube.GetLength(0);
	}

	public int[,,] FillCube(int size)
	{
		int[,,] cube = new int[size, size, size];

		Random random = new Random();
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				for (int q = 0; q < size; q++)
				{
					cube[i, j, q] = random.Next(0, 2);
				}
			}
		}
		return cube;
	}

    private int[,,] FillCubeIncrementally(int size)
    {
        int[,,] cube = new int[size, size, size];
        int count = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int q = 0; q < size; q++)
                {
                    cube[i, j, q] = count++;
                }
            }
        }
        return cube;
    }

	private Graph LinkVertices(int[,,] cube, int size)
	{
        Graph graph = new Graph(size * size * size);

        int[,,] cubeInc = FillCubeIncrementally(size);

        int count = 0;

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int q = 0; q < size; q++)
                {
                    //adjacent vertices
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int n = -1; n <= 1; n++)
                        {
                            if (count == 18)
                            {
                                int e = cube[i, j, q];
                            }
                            try
                            {
                                if(count == 6)
                                {
                                    Console.WriteLine();
                                }   
                                int value = cube[i + 1, k + j, n + q];
                                if (value == 0 && cube[i,j,q] != 1)
                                {
                                    graph.AddEdge(count, cubeInc[i + 1, k + j, n + q], q, j);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                continue;
                            }
                        }
                    }
                    count++;
                }
            }
        }

        for (int j = 0; j < size; j++)
        {
            for (int q = 0; q < size; q++)
            {
                if (cube[size - 1, j, q] != 1)
                {
                    graph.AddEdge(count, cubeInc[size - 1, j, q], q, j);
                }
                count++;
            }
        }

        return graph;
	}

    public List<((int col, int row), (int col, int row))> CheckDFSForEveryTopVertex(CubeShape cube)
    {
        Graph graph = LinkVertices(Cube,Size);
        List<((int row, int col), (int row, int col))> edges = new List<((int row, int col), (int row, int col))> ();

        for (int i = 0; i < cube.Size * cube.Size; i++)
        {
            var res = graph.DFS(i, cube.Size);
            int start = res.start;
            int finish = res.finish;
            if (start >= 0 && finish > 0)
            {
                edges.Add(
                    ((graph.AdjacencyList[start].First().col, graph.AdjacencyList[start].First().row), 
                    (graph.AdjacencyList[finish].First().col, graph.AdjacencyList[finish].First().row)));
            }
        }
        return edges;
    }

    public override string ToString()
    {
        StringBuilder cubeRepresentation = new StringBuilder();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                for (int q = 0; q < Size; q++)
                {
                    cubeRepresentation.Append(Cube[i, j, q] + " ");
                }
                cubeRepresentation.Append("\n");
            }
            cubeRepresentation.Append("\n");
        }
        return cubeRepresentation.ToString().Trim();
    }
}