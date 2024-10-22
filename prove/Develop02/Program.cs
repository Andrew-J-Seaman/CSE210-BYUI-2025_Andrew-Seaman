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
        user.GreetUserWhoIsNewOrExisting(user._currentUserID);
        // Using the 'currentUserID' complete and define the files paths for the user's 'Journal.csv' and 'Prompts.csv'


        // JOURNAL OBJECT

        Journal workingJournal = new Journal();
        // Pass user data file paths from 'user' instance to 'workingJournal' instance for 'Journal.csv' and 'Prompts.csv'
        workingJournal.GetUserJournalFilePathFromUserClassObj(user._currentUserJournalFilePath);


        // MAIN MENU OBJECT
        
        Menu menus = new Menu();
        menus.MainMenuLoop();
        int choice = menus._selectedKeyMainMenuLoop;

        switch (choice)
        {
            case 1:     // Write 
                Prompt prompt = new Prompt();
                prompt.GetUserPromptsFilePathsFromUserClassObj(user._currentUserPromptsFilePath);



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