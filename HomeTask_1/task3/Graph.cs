namespace task3;
//Графи мають недолік, що з ними важко працювати з великими розмірностями...
public class Graph
{
    private int _vertices;
    public List<(int  ind, int col, int row)>[] AdjacencyList;

    public Graph(int vertices)
    {
        _vertices = vertices;
        AdjacencyList = new List<(int ind, int col, int row)>[vertices];
        for (int i = 0; i < vertices; ++i)
        {
            AdjacencyList[i] = new List<(int ind, int col, int row)>();
        }
    }

    public void AddEdge(int v, int ind, int start, int finish)
    {
        AdjacencyList[v].Add((ind,start,finish));
    }

    private void DFSUtility(int v, bool[] visited, int size, out int start, out int finish)
    {
        visited[v] = true;

        finish = --size <= 0 ? v : -1;

        List<(int ind, int start, int end)> vList = AdjacencyList[v];
        foreach (var n in vList)
        {
            if (!visited[n.ind])
            {
                DFSUtility(n.ind, visited, size, out start, out finish);
            }
        }
        start = v;
    }

    public (int start, int finish) DFS(int v, int size)
    {
        bool[] visited = new bool[_vertices];

        int start = -1;
        int finish = -1;
        DFSUtility(v, visited, size, out start, out finish);
        return (start, finish);
    }
}
