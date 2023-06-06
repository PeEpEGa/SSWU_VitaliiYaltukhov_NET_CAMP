public class CardValidator
{
    private List<Card> _cards;
    private string _cardNumber;

    public CardValidator(string cardNumber)
    {
        _cardNumber = cardNumber;
        _cards = new List<Card> { new MasterCard(_cardNumber), new AmericanExpress(_cardNumber), new Visa(_cardNumber) };
    }

    public Card Validation()
    {
        int length = _cards.Count();
        for (int i = 0; i < length; i++)
        {
            if (_cards[i].CardValidation())
            {
                return _cards[i];
            }
        }
        throw new ArgumentException("incorrect card number");
    }
}