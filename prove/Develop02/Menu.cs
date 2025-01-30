// AUTHOR: Andrew Seaman
// TITLE: Menu Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

using System.Xml.Serialization;

public class Menu
{
    /* >>> ATTRIBUTES <<< =========================================================================
    //
    //      1) _mainMenu
    //      2) _choice
    //      3) _message1
    //      4) _message2
    //      5) _message3
    //
    //===========================================================================================*/
    // 1)
    private Dictionary<int, string> _mainMenu;

    // 2)
    public int _choice;

    // 3)
    private string _message1;

    // 4)
    private string _message2;

    // 5)
    private string _message3;

    /* >>> INSTANCES (1) <<< ======================================================================
    //
    //      1) Delay > delay
    //
    //===========================================================================================*/
    // 1)
    Delay delay = new Delay();

    /* >>> CONSTRUCTORS (1) <<< ===================================================================
    //
    //      1) _mainMenu
    //
    //===========================================================================================*/
    public Menu()
    {
        _mainMenu = new Dictionary<int, string>()
        {
            { 1, "Load" },
            { 2, "Display" },
            { 3, "Write" },
            { 4, "Save" },
            { 5, "Quit" },
        };
    }

    /* >>> METHODS - PUBLIC (5) <<< ===============================================================
    //
    //      1) DisplayMenuSelection
    //      2) SetGreeting
    //      3) DisplayGreeting
    //      4) SetDeparting
    //      5) DisplayDeparting
    //
    //===========================================================================================*/
    // 1) Display menu
    public void DisplayMenuSelection()
    {
        int choice;
        bool isInt = false;

        do
        {
            // Print menu options (1-5)
            foreach (KeyValuePair<int, string> kvp in _mainMenu)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
            }

            // Request menu selection (1-5)
            Console.Write("\n> Select a number: ");

            // Try to parse the input and check if it’s within the valid range
            if (int.TryParse(Console.ReadLine().Trim(), out choice) && choice >= 1 && choice <= 5)
            {
                _choice = choice; // Assign valid choice to the class variable
                isInt = true; // Exit loop
            }
            else
            {
                // Error (invalid entry)
                _message1 = "Error: invalid entry.";
                // Suggest next action
                _message2 = "Please select a number (1-5).";
                delay.Display2(_message1, _message2);
            }
        } while (!isInt);
    }

    // 2) Set greeting message
    public void SetGreeting()
    {
        _message1 = "Welcome! Let's Journal!";
    }

    // Display greeting message
    public void DisplayGreeting()
    {
        delay.Display1(_message1);
    }

    // 3) Set departing message
    public void SetDeparting()
    {
        // Success message
        _message1 = "Quitting...";
        _message2 = "Done!";
        // Departing message
        _message3 = "See you tomorrow!";
    }

    // Display departing message
    public void DisplayDeparting()
    {
        delay.Display3(_message1, _message2, _message3);
    }
}
































/* ORIGINAL CODE: Menu.cs


// AUTHOR: Andrew Seaman


using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


public class Menu
{
    public int _selectedKeyMainMenuLoop;

    public void MainMenuLoop()
    {
        // Create a list of actions; current length: 4 items
        List<string> menu_dict_values = new List<string>
        {
            "Write a new entry",        // 1
            "Display the journal",      // 2
            "Change User",              // 3
            "Exit Program"              // 4
        };

        int menu_length = menu_dict_values.Count;

        // Generate keys from 1 to menu_length using LINQ to a list
        List<int> menu_dict_keys = Enumerable.Range(1, menu_length).ToList();

        // Combine keys and values into a dictionary using LINQ's Zip method
        Dictionary<int, string> menuOptions = menu_dict_keys
            .Zip(menu_dict_values, (key, value) => new { key, value })
            .ToDictionary(x => x.key, x => x.value);

        // Redefine class attribute as shortened local variable name
        int selectedKey = _selectedKeyMainMenuLoop;
        bool validKeySelection = true;
        do
        {
            // Print menu title
            Console.WriteLine("Menu:");

            // Print menu: dictionary where each key maps to an Action.
            foreach (KeyValuePair<int, string> kvp in menuOptions) //replaced 'var' with 'KeyValuePair<int, Action>'
            {
                Console.WriteLine($"\t{kvp.Key}. {kvp.Value}");
            }

            // Gets user input for menu option selection
            Console.Write($"\n\tSelect a number(1-{menu_length}): ");
            selectedKey = int.Parse(Console.ReadLine());

            // Running an action from the dictionary using the selected key
            if (menuOptions.ContainsKey(selectedKey))
            {
                validKeySelection = true;
            }
            else
            {
                Console.WriteLine($"\t{selectedKey} is not a valid selection.");
                validKeySelection = false;
            };
        } while (!validKeySelection);
        
        // Redefine class attribute with value of shortened local variable
        _selectedKeyMainMenuLoop = selectedKey;
    }

    public void SaveDeleteMenu()
    {

    }
}


*/
