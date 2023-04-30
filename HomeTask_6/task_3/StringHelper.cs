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

                //find first and last words
                int indOfFirstWord = words.IndexOf(temp.ToString(), i);
                int indOfLastWord = words.LastIndexOf(temp.ToString());

                //check if they're the same (if not remove them)
                if (indOfFirstWord != indOfLastWord)
                {
                    bool onlyOne = true;
                    //remove identical
                    while (indOfLastWord != indOfFirstWord)
                    {
                        int indOfSpc = words.IndexOf(' ', indOfLastWord);
                        int a = words.LastIndexOf(' ', indOfLastWord);
                        if (indOfSpc - indOfLastWord == temp.Length && a == indOfLastWord - 1)
                        {
                            onlyOne = false;
                            indOfFirstWord = -1;
                            words = words.Remove(indOfLastWord, indOfSpc - indOfLastWord);
                        }
                        indOfLastWord = words.LastIndexOf(temp.ToString(), indOfLastWord - 1);
                    }
                    //if nothing has been removed return this word
                    if (onlyOne)
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