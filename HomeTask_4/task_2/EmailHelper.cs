public static class EmailHelper
    {
        private static List<(string, bool)> ExtractEmailAddresses(string text)
        {
            List<(string, bool)> res = new List<(string, bool)>();

            text = "  " + text + " ";

            int startOfTheWord = 0;
            int endOfTheWord = 0;

            int quoteInd = -1;
            int endOfTheEntrance = -1;

            for (int i = 0; i < text.Length; i++)
            {
                bool quoted = false;
                if (text[i] == '@')
                {
                    int tempQuoteStartInd = -1;
                    int tempQuoteEndInd = -1;

                    //if this situation: ( (local-part)"@(domain-part) )
                    if (text[i - 1] == '"' && text[i - 2] != '\\')
                    {
                        int tempQuoteInd = text.LastIndexOf('"', i - 2);
                        if (tempQuoteInd == quoteInd)
                        {
                            continue;
                        }

                        startOfTheWord = text.LastIndexOf(' ', tempQuoteInd);
                        endOfTheWord = text.IndexOf(' ', i);

                        quoteInd = i - 1;
                        endOfTheEntrance = endOfTheWord;

                        quoted = true;
                    }
                    else
                    {
                        int startInd = i;
                        do
                        {
                            tempQuoteStartInd = text.LastIndexOf('"', startInd);
                            startInd = tempQuoteStartInd - 1;
                        } while (tempQuoteStartInd != quoteInd && text[tempQuoteStartInd - 1] == '\\');


                        if (tempQuoteStartInd != quoteInd) //( "(local@-part)"@(domain-part) )
                        {
                            startOfTheWord = text.LastIndexOf(' ', tempQuoteStartInd);

                            int tempQuoteEnd = i;
                            do
                            {
                                tempQuoteEndInd = text.IndexOf('"', tempQuoteEnd);
                                tempQuoteEnd = tempQuoteEndInd + 1;
                            } while (tempQuoteEndInd != -1 && text[tempQuoteEndInd - 1] == '\\');

                            if (tempQuoteEndInd == -1)
                            {
                                quoteInd = tempQuoteStartInd;
                                continue;
                            }

                            endOfTheWord = text.IndexOf(' ', tempQuoteEndInd);
                            endOfTheEntrance = i + 1;

                            quoteInd = tempQuoteEndInd;
                            quoted = true;
                        }
                        else //( (local-part)@(domain-part) )
                        {
                            startOfTheWord = text.LastIndexOf(' ', i);
                            endOfTheWord = text.IndexOf(' ', i);

                            quoteInd = text.LastIndexOf('"', i);
                            endOfTheEntrance = i;
                        }
                    }

                    string result = text.Substring(startOfTheWord + 1, endOfTheWord - startOfTheWord - 1);
                    if (!(res.Count > 1 && res[res.Count - 1].Item1.IndexOf(result) != -1))
                    {
                        res.Add((result, quoted));
                    }

                    i = endOfTheEntrance;
                }
            }

            //delete seperators if exist in the end
            int length = res.Count;
            for (int i = 0; i < length; i++)
            {
                char lastSymbol = res[i].Item1.LastOrDefault();
                if (lastSymbol == ',' || lastSymbol == '.' || lastSymbol == '!' || lastSymbol == '?')
                {
                    res[i] = (res[i].Item1.Remove(res[i].Item1.Length - 1, 1), res[i].Item2);
                }
            }

            return res;
        }

        public static List<string> CorrectEmailAddresses(string text)
        {
            var wordsWithAtSign = ExtractEmailAddresses(text);

            List<string> correctEmails = new List<string>();

            string localPart = "";
            string domain = "";

            char[] forbiddenCharacters = new char[] { '(', ')', ',', ':', ';', '<', '>', '\"', '[', ']', '\\' };


            int length = wordsWithAtSign.Count;
            for (int i = 0; i < length; i++)
            {
                //validate quoted
                if (wordsWithAtSign[i].Item2)
                {
                    string email = wordsWithAtSign[i].Item1;
                    int indOfLastQuote = email.LastIndexOf('"');
                    if (email[indOfLastQuote + 1] != '@')
                    {
                        continue;
                    }
                    localPart = email.Substring(0, indOfLastQuote);
                    domain = email.Substring(indOfLastQuote + 2);
// такі константи слід винести за межі коду метода
                    if (localPart.Length > 64 || domain.Length > 255)
                    {
                        continue;
                    }

                    //domain-part
                    if (DomainValidation(domain))
                    {
                        correctEmails.Add(email);
                    }
                }
                else //validate unquoted
                {
                    var partsOfEmail = wordsWithAtSign[i].Item1.Split('@');

                    //check if any of the parts is empty
                    if (partsOfEmail.Length != 2 || partsOfEmail.Any(n => n == ""))
                    {
                        continue;
                    }

                    //assigning values
                    localPart = partsOfEmail[0];
                    domain = partsOfEmail[1];

                    //check if any of the parts is longer than should be
                    if (localPart.Length > 64 || domain.Length > 255)
                    {
                        continue;
                    }

                    //local-part
                    if (localPart.Any(n => forbiddenCharacters.Any(x => x == n) || Char.IsControl(n))
                        || !DoubleDotValidation(localPart))
                    {
                        continue;
                    }

                    //domain-part
                    if (DomainValidation(domain))
                    {
                        correctEmails.Add(wordsWithAtSign[i].Item1);
                    }
                }
            }
            return correctEmails;
        }


        private static bool DomainValidation(string domain)
        {
            if ((domain.First() == '-' || domain.Last() == '-'))
            {
                return false;
            }
            for (int j = 0; j < domain.Length; j++)
            {
                if (!Char.IsLetter(domain[j]) && !Char.IsDigit(domain[j]) && domain[j] != '-' && domain[j] != '.')
                {
                    return false;
                }
            }
            return DoubleDotValidation(domain);
        }

        private static bool DoubleDotValidation(string partOfEmail)
        {
            for (int j = 0; j < partOfEmail.Length - 1; j++)
            {
                int indOfDot = partOfEmail.IndexOf('.', j);
                if (indOfDot == -1)
                {
                    break;
                }
                j = indOfDot;
                if (partOfEmail[indOfDot + 1] == '.')
                {
                    return false;
                }
            }
            return true;
        }
    }
