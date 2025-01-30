// AUTHOR: Andrew Seaman
// TITLE: Program Class
// DISCLOSURE: Development was aided by Chat GPT 4.0


using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        /* >>> INSTANCES (2) <<< ==================================================================
        //
        //      1) Journal: `workingJournal`
        //      1) Menu:    `menu`
        //
        //=======================================================================================*/
        // 1) New Journal object
        Journal workingJournal = new Journal();
        // 2) Mew Menu object
        Menu menu = new Menu();

        /* >>> METHODS - Greeting message (2) <<< =================================================
        //
        //      1) SetGreeting
        //      2) DisplayGreeting
        //
        //=======================================================================================*/
        // 1)
        menu.SetGreeting();
        // 2)
        menu.DisplayGreeting();

        /* >>> METHODS - SWITCH CASE () <<< ================================================
        //
        //  > Display menu:
        //      1) DisplayMenuSelection()
        //
        //  > Menu options (5):
        //      2) LOAD:        LoadEntries()
        //      3) DISPLAY:     DisplayEntries()
        //      4) WRITE:       WriteEntry()
        //      5) SAVE:        SaveEntries()
        //      6) QUIT:        6a. SetDeparting()
        //                      6b. DisplayDeparting()
        //
        //=======================================================================================*/
        bool runJournal = true;
        do // Loop menu until the User quits the journal app
        {
            // 1)
            menu.DisplayMenuSelection();

            switch (menu._choice)
            {
                // 2) Load
                case 1:
                    workingJournal.LoadEntries();
                    break;
                // 3) Display
                case 2:
                    workingJournal.DisplayEntries();
                    break;
                // 4) Write
                case 3:
                    workingJournal.WriteEntry();
                    break;
                // 5) Save
                case 4:
                    workingJournal.SaveEntries();
                    break;
                // 6) Quit
                case 5:
                    runJournal = false;
                    // 6a)
                    menu.SetDeparting();
                    // 6b)
                    menu.DisplayDeparting();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        } while (runJournal != false);
    }
}














































/* ORIGINAL CODE: Program.cs


// AUTHOR: Andrew Seaman
// LAST UPDATE: 11/1/24

// For more on this assignment see: "https://byui-cse.github.io/cse210-course-2023/unit02/develop.html"


using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;


class Program
{
    static void Main(string[] args)
    {
        // Journal app opening greeting
        Console.WriteLine("\nThe Daily Journal");


        // USER OBJECT

        User user = new User();
        // Display users from 'Users.csv' and select one by their UserID.
        user.DisplayUsersAndSelectOne();
        // If needed, if userName is called "Empty" replace it with the user's first and last name.
        // Greet the new or returning user.
        user.GreetUserNewOrExisting(user._currentUserID);
        // Using the 'currentUserID' complete and define the files paths for the user's 'Journal.csv' and 'Prompts.csv'


        // JOURNAL OBJECT

        Journal currentJournal = new Journal();
        // Pass user data file paths from 'user' instance to 'workingJournal' instance for 'Journal.csv' and 'Prompts.csv'
        currentJournal.GetUserJournalFilePath(user._currentUserJournalFilePath);


        // MAIN MENU OBJECT
        
        Menu menus = new Menu();
        menus.MainMenuLoop();
        int choice = menus._selectedKeyMainMenuLoop;

        switch (choice)
        {
            case 1:     // Write
                Console.WriteLine("Let's write!\n");

                Prompt currentPrompt = new Prompt();
                currentPrompt.GetUserPromptsFilePaths(user._currentUserPromptsFilePath);

                // Entry currentEntry = new Entry(Prompt._newPrompt);



                break;

            case 2:     // Display



                break;

            case 3:     // Change User
                

                                
                break;

            case 4:     // ExitProgram



                break;
        }
    }
}


*/
