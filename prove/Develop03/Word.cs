using System;

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
    public Word(
            string text, 
            bool isHidden
            )
    {
        _text = text;
        _isHidden = isHidden;
    }
    
//==============================
// METHODS
//      1) + GetIsHidden : bool
//      2) + Hide()
//      3) + DisplayWord()
//——————————————————————————————

// 1)
    public bool GetIsHidden(){
        return _isHidden;
    }

// 2)
    public void Hide(){
        
    }

// 3)
    public void DisplayWord(){
        
    }









}