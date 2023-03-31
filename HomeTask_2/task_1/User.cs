namespace Homework2;

public class User
{
    private double _consumption;

    public User(int consumption)
    {
        _consumption = consumption;
    }

    public override string ToString()
    {
        return $"User consumption: {_consumption}.";
    }
}