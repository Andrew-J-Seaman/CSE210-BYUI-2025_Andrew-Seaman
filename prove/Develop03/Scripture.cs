using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class Scripture
{
//===========================================
// ATTRIBUTES
//      1) - _reference : Reference
//      2) - _words : List<Word>
//===========================================

// 1)
    private Reference _reference;
// 2)
    private List<Word> _words = new List<Word>();

//===========================================
// CONSTRUCTOR                               
//      1) + Scripture(reference : Reference    Complete: YES
//===========================================

// 1)
    public Scripture(Reference reference)
    {
        _reference = reference;
    }

//===========================================
// METHODS
//      1) + SetWords()                         Complete: YES
//      2) - RandNumGen() : int                 Complete: YES
//      3) + HideWords()                        Complete: NO
//      4) + DisplayScripture()                 Complete: NO
//      5) + IsAllHidden() : bool               Complete: YES
//===========================================

// 1)
    public void SetWords(string verseText){
        string[] splitText = verseText.Split(" ");

        foreach (string text in splitText){
            Word word = new Word(text, false);
            _words.Add(word);
        }
    }
// 2)
    private int RandNumGen(){
        // Generate random number
        Random random = new Random();
        int randomNum = random.Next(0, _words.Count());
        
        return randomNum;
    }

// 3)
    public void HideWords(){
        int i = 0;
        while (i != 3) {
            int randomNum = RandNumGen();
            if(_words[randomNum].GetIsHidden() == false){
                _words[randomNum].Hide();
                ++i;
            }
        }
    }

// 4)
    public void DisplayScripture(){
        foreach (Word word in _words){
            
            Console.Write($"{word.GetText()} ");
        }
        
    }

// 5)
    public bool IsAllHidden(){
        foreach (Word word in _words){
            if (word.GetIsHidden() == false){
                return false;
            }
        }
        return true;
    }
}