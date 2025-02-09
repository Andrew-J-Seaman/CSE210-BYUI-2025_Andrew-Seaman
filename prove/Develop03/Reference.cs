using System;
using System.Collections.Concurrent;

public class Reference
{
    //================================
    // ATTRIBUTES
    //      1) - _book : string
    //      2) - _chapter : string
    //      3) - _verse1 : string
    //      4) - _verseEnd : string
    //————————————————————————————————

    // 1)
    private string _book;

    // 2)
    private string _chapter;

    // 3)MakeDelay
    private string _verse1;

    // 4)
    private string _verseEnd;
    private string _refToPrint;

    //================================
    // CONSTRUCTOR
    //      1) + Reference (
    //              book : string,
    //              chapter : string,
    //              verse1 : string,
    //              verseEnd : string
    //              )
    //————————————————————————————————

    // 1)
    public Reference(string book, string chapter, string verse1, string verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verseEnd = verseEnd;
    }

    //================================
    // METHODS
    //      1) + DisplayRef()           Complete: YES
    //————————————————————————————————

    // 1)
    public void DisplayRef()
    {
        if (_verseEnd == null)
        {
            _refToPrint = $"{_book} {_chapter}:{_verse1}";
        }
        else
        {
            _refToPrint = $"{_book} {_chapter}:{_verse1}-{_verseEnd}";
        }
        Console.WriteLine(_refToPrint);
    }
}
