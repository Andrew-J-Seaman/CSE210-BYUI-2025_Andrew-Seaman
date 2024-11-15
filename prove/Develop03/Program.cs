using System;

class Program
{
    static void Main(string[] args)
    {
        // New Reference obj
        Reference reference = new Reference("Proverbs", "3", "4", "6");

        // New Scripture obj
        Scripture scripture = new Scripture(reference);
        string verseText = "So shalt thou find favour and good understanding in the sight of God and man. Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        scripture.SetWords(verseText);
        
        
        do {
            Console.Clear();
            reference.DisplayRef();
            scripture.DisplayScripture();

            string user_input = Console.ReadLine().ToLower();
            if (user_input == "quit"){
                return;
            }

            scripture.HideWords();

        // Test if all words are hidden
        } while (scripture.IsAllHidden() != true);

        Console.Clear();
        reference.DisplayRef();
        scripture.DisplayScripture();
    }

}






// ACTION STEPS:

    // 1. Add in all functions
    // 2. Hide 1 word; then
    // 3. Hide 1 random word
    // 4. Hide 3 random words   // This is the end goal inside of HideWords() from Scripture class.