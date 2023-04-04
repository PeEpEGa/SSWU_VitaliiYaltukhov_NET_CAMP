namespace Homework2;

public class WaterTower
{
    public int TowerId;
    private readonly double _capacity;
    private double _currentLevel;
    private Pump[] _pumps;

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
        TowerId = SetId();
    }
    public WaterTower(int maxLevelWater, Pump[] pump)
    {
        _capacity = maxLevelWater;
        _pump = pump;
        TowerId = SetId();
    }

    private void SetId()
    {
    } 

    public override string ToString()
    {
        return $"WaterTower id: {TowerId}. Max capacity:{_capacity}.";
    }
}