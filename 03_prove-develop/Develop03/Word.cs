using System;
using System.Security.AccessControl;

public class Word
{
    //==============================
    // ATTRIBUTES
    //      1) - _text : string
    //      2) - _isHidden : bool
    //——————————————————————————————

    // 1)
    private string _text;

    // 2)
    private bool _isHidden;

    //==============================
    // CONSTRUCTOR
    //      1) + Word(
    //              text : string,
    //              isHidden : bool
    //              )
    //——————————————————————————————

    // 1)
    public Word(string text, bool isHidden)
    {
        _text = text;
        _isHidden = isHidden;
    }

    //==============================
    // METHODS
    //      1) + GetIsHidden : bool     Complete: YES
    //      2) + Hide()                 Complete: YES
    //      3) + DisplayWord()          Complete: YES
    //——————————————————————————————

    // 1)
    public bool GetIsHidden()
    {
        return _isHidden;
    }

    // 2)
    public void Hide()
    {
        int numOfCharacters = 1;
        string isPeriod = _text.Substring(_text.Length - numOfCharacters);
        if (isPeriod == ".")
        {
            _text = "___.";
        }
        else
        {
            _text = "___";
        }
        _isHidden = true;
    }

    // 3)
    public string GetText()
    {
        return _text;
    }
}
