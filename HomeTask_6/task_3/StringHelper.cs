using System.Text;
using System.Text.RegularExpressions;

namespace task2._1_sigma_
{
    public static class StringHelper
    {
        public static IEnumerable<string> FindUniqueWords(string text)
        {
            string words = " " + Regex.Replace(text, @"\s+", " ") + " ";

            StringBuilder temp = new StringBuilder();
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i] == ' ')
                {
                    continue;
                }
                //find space-character
                int indOfSpace = words.IndexOf(' ', i);

                
                temp.Append(words.Substring(i, indOfSpace - i));

                //find word
                int indOfFirstWord = words.IndexOf(temp.ToString(), i);
                int indOfLastWord = words.LastIndexOf(temp.ToString());
                if (indOfFirstWord != indOfLastWord)
                {
                    indOfFirstWord = indOfLastWord;
                    while (indOfLastWord != -1)
                    {
                        int indOfSpc = words.IndexOf(' ', indOfLastWord);
                        if (indOfSpc - indOfLastWord == temp.Length)
                        {
                            words = words.Remove(indOfLastWord, indOfSpc - indOfLastWord);
                        }
                        indOfLastWord = words.LastIndexOf(temp.ToString(), indOfLastWord - 1);
                    }
                    if (indOfFirstWord == indOfLastWord)
                    {
                        yield return temp.ToString();
                        i = indOfSpace;
                    }
                }
                else
                {
                    yield return temp.ToString();
                    i = indOfSpace;
                }
                temp = new StringBuilder();
            }
        }
    }
}