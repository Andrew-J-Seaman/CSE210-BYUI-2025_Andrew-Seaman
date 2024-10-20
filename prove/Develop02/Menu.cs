using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


public class Menu
{
    // Initialize methods
    public void MenuLoop()
    {   
        // String formating constants
        string INDENT = "   ";
        string CARROT = ">";

        // Create a list of actions
        List<Action> menu_dict_values = new List<Action>
        {
            Write, 
            Display, 
            Load, 
            Save, 
            ExitProgram
        };

        int menu_length = menu_dict_values.Count;

        // Generate keys from 1 to menu_length using LINQ to a list
        List<int> menu_dict_keys = Enumerable.Range(1, menu_length).ToList();

        // Combine keys and values into a dictionary using LINQ's Zip method
        Dictionary<int, Action> menuOptions = menu_dict_keys
            .Zip(menu_dict_values, (key, value) => new { key, value })
            .ToDictionary(x => x.key, x => x.value);

        bool validSelectedKey = true;
        do
        {
            // Print menu title
            Console.WriteLine("Menu:");

            // Print menu: dictionary where each key maps to an Action.
            foreach (KeyValuePair<int, Action> kvp in menuOptions) //replaced 'var' with 'KeyValuePair<int, Action>'
            {
                Console.WriteLine($"{INDENT}{CARROT}{kvp.Key}. {kvp.Value.Method.Name}");
            }

            // Gets user input for menu option selection
            Console.Write($"\n{INDENT}{CARROT}Select a number: ");
            int selectedKey = int.Parse(Console.ReadLine());

            // Running an action from the dictionary using the selected key
            if (menuOptions.ContainsKey(selectedKey))
            {
                menuOptions[selectedKey].Invoke();
            }
            else
            {
                Console.WriteLine($"{CARROT}{selectedKey} is not a valid selection.");
                validSelectedKey = false;
            };
        } while (!validSelectedKey);
    }
    
    // Define functions for each menu option

    static void Write()
    {
        // Goal: return date, title, prompt, entry
        // In order: date, prompt, entry, title


        Entry newEntry = new Entry();
        Entry.TodayDate();                // Order 1: date
        = NewPrompt();                    // Order 2: prompt
        _entryNew = Entry.WriteEntry();   // Order 3: entry
        _entrytitle = Entry.GetTitle      // Order 4: title 























    }
    
    static void Display() => .Display();
    static void Load() => Console.WriteLine("Load operation");
    static void Save() => Console.WriteLine("Save operation");
    static void ExitProgram() => Console.WriteLine("Exiting program");
    
}

