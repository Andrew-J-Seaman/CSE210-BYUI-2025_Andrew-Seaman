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
// 3)
    private string _verse1;
// 4)
    private string _verseEnd;

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
    public Reference(
            string book, 
            string chapter, 
            string verse1, 
            string verseEnd
            )
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verseEnd = verseEnd;
    }

//================================
// METHODS
//      1) + DisplayRef()
//————————————————————————————————

// 1)
    public void DisplayRef(){

    }
}