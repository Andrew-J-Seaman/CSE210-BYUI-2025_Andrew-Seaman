using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Serialization;

class Program{

    static void Main(string[] args)
    {
        // Program greeting
        Console.Clear();
        Console.WriteLine("\nLet's journal!");

        // New journal object
        Journal workingJournal = new Journal();

        bool run = true;
        do 
        {
            Menu mainMenu = new Menu();
            mainMenu.DisplayMenuSelection();

            switch (mainMenu._choice)
            {
                case 1:     // Load
                    workingJournal.LoadEntries();
                    break;

                case 2:     // Display
                    workingJournal.DisplayEntries();
                    break;

                case 3:     // Write
                    workingJournal.WriteEntry();                
                    break;

                case 4:     // Save
                    workingJournal.SaveEntries();
                    break;

                case 5:     // Quit
                    run = false;
                    workingJournal.QuitJournal();
                    break;
                
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid choice. Please try again.");

                    break;
            }
        } while (run != false);
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