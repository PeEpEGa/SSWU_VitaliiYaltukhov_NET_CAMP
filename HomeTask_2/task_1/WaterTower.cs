namespace Homework2;

public class WaterTower
{
    private readonly int _capacity;
    private int _currentLevel;
    private Pump[] _pump;
    public int TowerId;

    public int MaxLevelWater 
    { 
        get {return _capacity; } 
        private set {}
    }
    public int CurrentLevel 
    { 
        get { return _currentLevel; }
        private set {}
    }

    public WaterTower()
    {
        TowerId = CreateId();
    }
    public WaterTower(int maxLevelWater, Pump[] pump)
    {
        _capacity = maxLevelWater;
        _pump = pump;
        TowerId = CreateId();
    }

    private int CreateId()
    {
        //temporary
        return 1;
    } 

    public override string ToString()
    {
        return $"WaterTower id: {TowerId}. Max capacity:{_capacity}.";
    }
}