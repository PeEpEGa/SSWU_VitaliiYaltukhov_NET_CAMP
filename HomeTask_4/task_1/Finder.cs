using System.Text;
public static class Finder
    {
        public static (int line, int index) IndBackward(string[] text, int lineIndex, int indexOfElement, char[] symbolToFind)
        {
            for (int i = indexOfElement; i >= 0; i--)
            {
                if (symbolToFind.Any(n => n == text[lineIndex][i]))
                {
                    return (lineIndex, i);
                }
            }
            if (lineIndex == 0)
            {
                return (0, -1);
            }

            var res = IndBackward(text, --lineIndex, indexOfElement = text[lineIndex].Length - 1, symbolToFind);
            return res;
        }

        public static (int line, int index) IndForward(string[] text, int lineIndex, int indexOfElement, char[] symbolToFind)
        {
            int ind = text[lineIndex].IndexOf(symbolToFind[0], indexOfElement);
            for (int i = 0; i < symbolToFind.Length; i++)
            {
                int temp = text[lineIndex].IndexOf(symbolToFind[i], indexOfElement);
                if (temp < ind && temp > -1)
                {
                    ind = temp;
                }
            }

            if (ind != -1)
            {
                return (lineIndex, ind);
            }
            else if (lineIndex == (text.Length - 1))
            {
                return (-1, -1);
            }

            var res = IndForward(text, ++lineIndex, indexOfElement = 0, symbolToFind);
            return res;
        }

        private static void AddText(ref StringBuilder sb, int startIndex, int line1, int lastIndex, int line2, string[] text)
        {
            for (int i = line1; i <= line2; i++)
            {
                int border = line1 == line2 ? lastIndex : text[line1].Length;
                for (int j = startIndex; j < border; j++)
                {
                    sb.Append(text[line1][j]);
                }
                line1++;
                startIndex = 0;
            }
        }

        public static string[] SentencesWithParenthesis(string[] text)
        {
            //in case that there is no end character in the end.
            text[text.Length - 1] = text[text.Length - 1] + ".";

            StringBuilder tempResult = new StringBuilder();
            List<string> result = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                (int line, int index) indOpenParenthesis = (-1, -1);
                (int line, int index) indCloseParenthesis = (-1, -1);
                (int line, int index) indFirstDot = (-1, -1);
                (int line, int index) indLastDot = (i, 0);
                while (true)
                {
                    try
                    {
                        indOpenParenthesis = IndForward(text, indLastDot.line, indLastDot.index, new char[] { '(' });

                        if (indOpenParenthesis.index == -1)
                        {
                            break;
                        }

                        indFirstDot = IndBackward(text, indOpenParenthesis.line, indOpenParenthesis.index, new char[] { '.', '!', '?' });
                        indCloseParenthesis = IndForward(text, indOpenParenthesis.line, indOpenParenthesis.index, new char[] { ')' });
                        indLastDot = IndForward(text, indCloseParenthesis.line, indCloseParenthesis.index, new char[] { '.', '!', '?' });


                        AddText(ref tempResult, indFirstDot.index + 1, indFirstDot.line, indLastDot.index, indLastDot.line, text);
                        result.Add(tempResult.ToString().Trim());
                        tempResult = new StringBuilder();
                        i = indLastDot.line;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return result.ToArray();
        }
    }