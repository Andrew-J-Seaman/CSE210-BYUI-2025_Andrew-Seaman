using System;

class Program
{
    static void Main(string[] args)
    {
        // New Reference obj
        Reference reference = new Reference("Proverbs", "3", "4", "6");

        // New Scripture obj
        Scripture scripture = new Scripture(reference);
        string verse = "Trust in the Lord...";
        scripture.SetWords(verse);
        












    }
}






// ACTION STEPS:

    // 1. Add in all functions
    // 2. Hide 1 word; then
    // 3. Hide 1 random word
    // 4. Hide 3 random words   // This is the end goal inside of HideWords() from Scripture class.