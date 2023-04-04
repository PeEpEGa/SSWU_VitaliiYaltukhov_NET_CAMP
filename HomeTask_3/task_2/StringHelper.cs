public static class StringHelper
{
    public static int IndexOfSecondSubstring(string text, string wordToFind)
    {
        int startIndex = 0;
        int index = text.IndexOf(wordToFind, startIndex);
        index = text.IndexOf(wordToFind, (startIndex = index) + 1);
        return index;
    }

    public static int AmountOfWordsWithFirstCapitalLetter(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(n => Char.IsUpper(n.FirstOrDefault())).Count();
    }

    public static string ChangeWordsWithDoubleLetters(string text, string wordToChange)
    {
        return Regex.Replace("(\\w)\\1", wordToChange);
        return res;
        StringBuilder result = new StringBuilder();
        StringBuilder temp = new StringBuilder();
        for (int i = 1; i < text.Length + 1; i++)
        {
            if (text[i - 1] == ' ')
            {
                result.Append(temp.ToString());
                temp = new StringBuilder();
                result.Append(" ");
                continue;
            }
            else if (i != text.Length && text[i] == text[i - 1])
            {
                result.Append(wordToChange + " ");
                temp = new StringBuilder();
                i = text.IndexOf(' ', i + 1);
                if(i == -1)
                {
                    break;
                }
                continue;
            }
            else
            {
                temp.Append(text[i - 1]);
            }
        }
        return temp.Length > 0 ? result.Append(temp).ToString() : result.ToString();
    }
}