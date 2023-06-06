List<string> cards = new List<string> {"5105105105105100", "4222222222222", "378282246310005"};

foreach (var card in cards)
{
    Console.Write("Type of card: ");
    CardValidator cv = new CardValidator(card);
    Console.WriteLine(cv.Validation());
}