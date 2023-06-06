public class MasterCard : Card
{
    public MasterCard(string number) : base(number)
    {
    }

    public override bool CardValidation()
    {
        string[] allowedBeginning = { "51", "52", "53", "54", "55" };
        if(base.Number.Length != 16 ||
            !allowedBeginning.Any(b => base.Number.StartsWith(b)) ||
            !base.Mod10())
        {
            return false;
        }
        return true;
    }
}