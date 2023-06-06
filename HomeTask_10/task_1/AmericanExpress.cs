public class AmericanExpress : Card
{
    public AmericanExpress(string number) : base(number)
    {
    }

    public override bool CardValidation()
    {
        string[] allowedBeginning = { "34", "37" };
        if (base.Number.Length != 15 ||
            !allowedBeginning.Any(b => base.Number.StartsWith(b)) ||
            !base.Mod10())
        {
            return false;
        }
        return true;
    }
}