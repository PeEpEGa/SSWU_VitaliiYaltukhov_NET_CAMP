namespace Homework2;

public class User
{
    public int Id;
    private double _consumption;

    public User(int consumption)
    {
        _consumption = consumption;
    }

    public override string ToString()
    {
        return $"User consumption: {_consumption}.";
    }

    public void ConsumeWater()
    {
    }
    
    private void SetId()
    {
    }
}