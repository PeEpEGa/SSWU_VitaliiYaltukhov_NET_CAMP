namespace Homework2;

public class Simulator
{
    private User[] _users;
    private WaterTower _waterTower;
    private Pump[] _pumps;

    public Simulator(User[] users, WaterTower waterTower, Pump pumps)
    {
        _users = users;
        _waterTower = waterTower;
        _pumps = pumps;
    }

    public void AddPump(Pump pump)
    {
    }
    public void RemovePump(Pump pump)
    {
    }

    public void AddUser(User user)
    {
    }
    public void RemoveUser(User user)
    {
    }
    
    public void FillWaterTower(double amount)
    {
    }
}