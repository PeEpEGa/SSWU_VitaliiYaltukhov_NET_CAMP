public class Visa : Card
{
    public Visa(string number) : base(number)
    {
    }

    public override bool CardValidation()
    {
        if ((base.Number.Length == 13 ||
            base.Number.Length == 16) &&
            base.Number.StartsWith("4") &&
            base.Mod10())
        {
            return true;
        }
        return false;
    }
}