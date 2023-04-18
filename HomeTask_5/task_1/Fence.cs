using System.Text;
public class Fence : IComparable<Fence>
{
    public List<Tree> Trees { get; set; }
    public double Length { get; set; }
    public Fence()
    {
        Trees = new List<Tree>();
        Length = 0;
    }
    public Fence(List<Tree> trees)
    {
        Trees = trees;
        Length = 0;//todo
    }

    private Tree NextToTop(Stack<Tree> stack)
    {
        Tree tree = stack.Peek();
        stack.Pop();
        Tree res = stack.Peek();
        stack.Push(tree);
        return res;
    }
    private static void Swap<T>(IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    public static double Distance(Tree tree1, Tree tree2)
    {
        return Math.Sqrt((tree1.X - tree2.X) * (tree1.X - tree2.X) + (tree1.Y - tree2.Y) * (tree1.Y - tree2.Y));
    }
    public static int Orientation(Tree p, Tree q, Tree r)
    {
        double val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
        if (val == 0) // colinear
        {
            return 0;
        }
        return val > 0 ? 1 : 2; // clock or counterclock wise
    }

    public Tree[] AddFence(List<Tree> trees, int n)
    {
        if(trees.Count == 0)
        {
            return new Tree[] { };
        }
        // Find the bottommost point
        double ymin = trees[0].Y;
        int min = 0;
        for (int i = 1; i < n; i++)
        {
            double y = trees[i].Y;
            // Pick the bottom-most or chose the left most point in case of tie
            if ((y < ymin) || (ymin == y && trees[i].X < trees[min].X))
            {
                ymin = trees[i].Y;
                min = i;
            }
        }

        // Place the bottom-most point at first position
        Swap(trees, 0, min);

        GlobalVariables.BottomTree = trees[0];

        trees.Sort(1, n - 1, Tree.SortTreesAscending());

        // If two or more points make same angle with p0. Remove all but the one that is farthest from p0
        for (int i = 1; i < trees.Count; i++)
        {
            // Keep removing i while angle of i and i+1 is same with respect to p0
            while (i < trees.Count - 1 && Orientation(GlobalVariables.BottomTree, trees[i], trees[i + 1]) == 0)
            {
                trees.Remove(trees[i]);
            }
        }

        // If modified array of points has less than 3 points, convex hull is not possible.
        if (trees.Count < 3) return new Tree[] { };

        Stack<Tree> result = new Stack<Tree>();
        result.Push(trees[0]);
        result.Push(trees[1]);
        result.Push(trees[2]);

        // Process remaining n-3 points
        for (int i = 3; i < trees.Count; i++)
        {
            while (Orientation(NextToTop(result), result.Peek(), trees[i]) != 2)
            {
                result.Pop();
            }
            result.Push(trees[i]);
        }

        return result.ToArray();
    }

    public double LengthOfTheFence(Tree[] trees)
    {
        int length = trees.Length;
        if (trees.Length < 2)
        {
            return 0;
        }
        double lengthOfTheFence = 0;
        for (int i = 1; i < trees.Length; i++)
        {
            lengthOfTheFence += Distance(trees[i - 1], trees[i]);
        }
        lengthOfTheFence += Distance(trees[0], trees[length - 1]);
        Length = lengthOfTheFence;
        return lengthOfTheFence;
    }

    public override string ToString()
    {
        StringBuilder res = new StringBuilder();
        res.Append("Trees:\n");
        foreach (var item in Trees)
        {
            res.AppendLine("X: " + item.X + " Y:" + item.Y);
        }
        return res.ToString();
    }

    //todo
    public int CompareTo(Fence fence)
    {
        return Length > fence.Length ? 1 : -1;
    }
}