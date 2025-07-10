using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // List of references (Book, Chapter, Start Verse, End Verse)
        // Note: use `null` when there's no End Verse.
        List<Reference> references = new List<Reference>()
        {
            new Reference("2nd Corinthians", "12", "7", "10"), // Ref 1
            new Reference("Proverbs", "3", "4", "6"), // Ref 2
            new Reference("Malachi", "3", "10", null), // Ref 3
            new Reference("Mormon", "8", "22", null), // Ref 4
            new Reference("2nd Nephi", "11", "4", "5"), // Ref 5
        };

        // List of verse text
        List<string> refText = new List<string>()
        {
            // Text 1: 2nd Corinthians 12:7-10
            new string(
                "And lest I should be exalted above measure through the abundance of the revelations, there was given to me a thorn in the flesh, the messenger of Satan to buffet me, lest I should be exalted above measure. For this thing I besought the Lord thrice, that it might depart from me. And he said unto me, My grace is sufficient for thee: for my strength is made perfect in weakness. Most gladly therefore will I rather glory in my infirmities, that the power of Christ may rest upon me. Therefore I take pleasure in infirmities, in reproaches, in necessities, in persecutions, in distresses for Christ’s sake: for when I am weak, then am I strong."
            ),
            // Text 2: Proverbs 3:4-6
            new string(
                "So shalt thou find favour and good understanding in the sight of God and man. Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            // Text 3: Malachi 3:10
            new string(
                "Bring ye all the tithes into the storehouse, that there may be meat in mine house, and prove me now herewith, saith the Lord of hosts, if I will not open you the windows of heaven, and pour you out a blessing, that there shall not be room enough to receive it."
            ),
            // Text 4: Mormon 8:22
            new string(
                "For the eternal purposes of the Lord shall roll on, until all his promises shall be fulfilled."
            ),
            // Text 5: 2nd Nephi 11:4-5
            new string(
                "Behold, my soul delighteth in proving unto my people the truth of the coming of Christ; for, for this end hath the law of Moses been given; and all things which have been given of God from the beginning of the world, unto man, are the typifying of him. And also my soul delighteth in the covenants of the Lord which he hath made to our fathers; yea, my soul delighteth in his grace, and in his justice, and power, and mercy in the great and eternal plan of deliverance from death."
            ),
        };

        bool run;
        do
        {
            Console.WriteLine("\n");
            for (int i = 0; i < references.Count(); ++i)
            {
                Console.Write($"{i + 1}. ");
                references[i].DisplayRef();
            }

            Console.Write("> Choose a reference (1-5): ");
            int choiceRef = int.Parse(Console.ReadLine());

            // Giving name to selected Reference obj
            Reference reference = references[choiceRef];

            // New Scripture obj
            Scripture scripture = new Scripture(reference);
            string verseText = refText[choiceRef];
            scripture.SetWords(verseText);

            do
            {
                Console.Clear();
                reference.DisplayRef();
                scripture.DisplayScripture();

                string user_input = Console.ReadLine().ToLower();
                if (user_input == "quit")
                {
                    return;
                }

                scripture.HideWords();

                // Test if all words are hidden
            } while (scripture.IsAllHidden() != true);

            Console.Clear();
            reference.DisplayRef();
            scripture.DisplayScripture();

            Console.WriteLine("\nContinue (Y/N)? ");
            string choiceRun = Console.ReadLine().ToLower();
            if (choiceRun == "y")
            {
                run = true;
            }
            else
            {
                run = false;
            }
        } while (run == true);
    }
}






// ACTION STEPS:

// 1. Add in all functions
// 2. Hide 1 word; then
// 3. Hide 1 random word
// 4. Hide 3 random words   // This is the end goal inside of HideWords() from Scripture class.
