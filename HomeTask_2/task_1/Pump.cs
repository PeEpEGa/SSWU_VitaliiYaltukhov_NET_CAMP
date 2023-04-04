namespace Homework2;

public class Pump
{
    public int Id;
    private readonly double _power;
    private bool _isOn = false;

    public bool IsOn
    {
        set { isOn = value; }
        get { return isOn; }
    }

    public Pump(double power)
    {
        _power = power;
    }

    public void ChangeState()
    {
    }
    
    private void SetId()
    {
    }

    public override string ToString()
    {
        return $"Pump power: {_power}.";
    }
}