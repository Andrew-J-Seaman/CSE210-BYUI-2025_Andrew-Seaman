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

