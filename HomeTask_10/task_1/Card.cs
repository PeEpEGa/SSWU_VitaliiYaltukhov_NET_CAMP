public class Card
{
    public string Number { get; set; }

    public Card(string number)
    {
        Number = number;
    }

    protected bool Mod10()
    {
        int checkSum = 0;
        for (int i = 0; i < Number.Length; i++)
        {
            int res = Number[Number.Length - i - 1] - '0';
            if (i % 2 != 0)
            {
                res *= 2;
                if (res > 9)
                {
                    res = (res - 1) % 9 + 1;
                }
            }
            checkSum += res;
        }
        return checkSum % 10 == 0;
    }

    public virtual bool CardValidation()
    {
        return Mod10();
    }
}