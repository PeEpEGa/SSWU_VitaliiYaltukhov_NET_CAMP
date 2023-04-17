string[] slicedText = new string[] 
{
    "Some text, (text in parenthesis) some text. Some text, (text in parenthesis)1 ?some text. Some text, ?(text in parenthesis)2 some ",
    "text. Some text, (text in parenthesis)3 some text. Text after dot.",
    "Some text, (text ",
    "in parenthesis) some text qwef. Text after dot.",
    "Some text, text ",
    "Some text, text ", 
    "Some text, text ",
    "Some text, text (ttt) text."
};

Console.WriteLine("Result:");
var res = Finder.SentencesWithParenthesis(slicedText);
foreach (var item in res)
{
    Console.WriteLine(item);
}
