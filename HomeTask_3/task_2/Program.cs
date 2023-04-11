// Користувач бере воду в вежі. Має бути зв'язок.
//task2.1
string text1 = "Avkweprojg  ger w ef R w g WEG  ger    f wfF WF fw f ff f fd ddA  f AA fw";

int result1 = StringHelper.IndexOfSecondSubstring(text1, "ger");
Console.WriteLine(result1);


//task2.2
string text2 = "Avkweprojg  ger w ef R w g WEG  ger    f wfF WF fw f ff f fd ddA  f AA fw";

int result2 = StringHelper.AmountOfWordsWithFirstCapitalLetter(text2);
Console.WriteLine(result2);


//task2.3
string wordToReplace = "qwerty";
string text3 = "abba af   aqq      trbnkm  rrhj";

string result3 = StringHelper.ChangeWordsWithDoubleLetters(text3, wordToReplace);
Console.WriteLine(result3);
