using System.Text;
public class Tree : IComparer<Tree> //, IComparable
{
    public double X { get; set; }
    public double Y { get; set; }

    public Tree()
    {
        X = 0;
        Y = 0;
    }
    public Tree(double x, double y)
    {
        X = x;
        Y = y;
    }

    public int Compare(Tree x, Tree y)
    {
        int orientation = Fence.Orientation(GlobalVariables.BottomTree, x, y);
        if (orientation == 0)
        {
            return (Fence.Distance(x, GlobalVariables.BottomTree) >= Fence.Distance(x, y)) ? -1 : 1;
        }
        return orientation == 2 ? -1 : 1;
    }

    public static IComparer<Tree> SortTreesAscending()
    {
        return new Tree();
    }
}