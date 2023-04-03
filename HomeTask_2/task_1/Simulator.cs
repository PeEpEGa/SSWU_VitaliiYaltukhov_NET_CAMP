namespace Homework2;

public class Simulator : IMediator
{
    private User[] _user;
    private WaterTower _waterTower;
    private Pump[] _pump;

    public Simulator(User[] user, WaterTower waterTower, Pump pump)
    {
        _user = user;
        _waterTower = waterTower;
        _pump = pump;
    }
    public override void Consume()
    {

    }
}