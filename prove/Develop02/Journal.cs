using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System;


public class Journal{
    private List<Entry> _entries;
    private List<Entry> _newEntries;
    private string _journalFilePath;

    Delay delay = new Delay();

    private string _message1;
    private string _message2;
    private string _message3;

    private bool _reloading;

//=========================================
    // MENU options (relevant to JOURNAL):
    //      1) Load
    //      2) Display
    //      3) Write
    //      4) Save
    //      5) Quit
//=========================================


    // 1) Load
    public void LoadEntries(){
        // Get file name if undefined
        if (_journalFilePath == null){
            Console.Write($"> Enter file name: ");
            string journalFileName = Console.ReadLine();
            _journalFilePath = journalFileName;
        }

        // Read all lines from journal file
        string[] lines = File.ReadAllLines(_journalFilePath);

        // Loop through each line
        foreach (string line in lines){
            // Split the line by the '~' character
            string[] parts = line.Split('~');

            // Ensure there are exactly three parts (for entryDate, randomPrompt, response)
            if (parts.Length == 3){
                // Create a new Entry object and set its properties
                Entry entry = new Entry();
                entry._entryDate = parts[0].Trim();
                entry._randomPrompt = parts[1].Trim();
                entry._response = parts[2].Trim();

                // Add the Entry object to the _entries list
                if (_entries == null)
                {
                    _entries = [];
                }
                _entries.Add(entry);
            }
            else{
                Console.WriteLine($"Invalid line format: {line}");
            }
        }

        // Progress/Success message (Loading/Reloading)
        if (_reloading == true){
            _message1 = "Reloading...";
        }
        else {
            _message1 = "Loading...";
        }
        
        _message2 = "Done!";
        // Suggest next action
        _message3 = "Select (2) to display the journal or (3) to write a new entry.";

        delay.Display3xxxClxWr1xWaLxWr2xWaSxClxWr3xWaSxNl(_message1, _message2, _message3);
        // Set bool to False
        _reloading = false;
    }

    // 2) Display
    public void DisplayEntries(){
        if (_entries == null){
            // Error message (no entries found)
            _message1 = "No entries found.";
            // Suggest next action
            _message2 = "Select (1) to load a journal.";
            delay.DisplayErr2xxxClxWrxWaLxD1xClxWr1xNlxWaS(_message1, _message2);
            
        }
        else{
            // Progress message (displaying)
            _message1 = "Displaying...";
            _message2 ="Done!";
            delay.Display2xxxClxWr1xWaLxWr2xWaSxCl(_message1, _message2);

            // Print out entries
            foreach(Entry entry in _entries){
                entry.DisplayEntry();
            }
        }
    }

    // 3) Write
    public void WriteEntry(){
        // New Prompt object
        Prompt prompt = new Prompt();

        // Create a new Entry object
        Entry newEntry = new Entry();

        // Get date. Save property
        newEntry._entryDate = DateTime.Today.ToString("d");
        // Get random prompt. Save property
        newEntry._randomPrompt = prompt.PromptGenerator();

        // Progress/Success message (generating prompt)
        _message1 = "Generating prompt...";
        _message2 ="Done!";
        delay.Display2xxxClxWr1xWaLxWr2xWaSxCl(_message1, _message2);
        // Greeting message
        _message1 = "Let's write! Press (return/enter) key when finished.";
        delay.Display1xxxClxWr1xNlxWaS(_message1);
        
        // Display random prompt
        Console.WriteLine($"Prompt: {newEntry._randomPrompt}");

        // Get user response. Save property
        Console.Write("> Response: ");
        newEntry._response = Console.ReadLine();

        // Add newEntry to `_unsavedEntries`
        if (_newEntries == null){
            _newEntries = new List<Entry> {newEntry};
        }
        else{
            _newEntries.Add(newEntry); 
        }

        // Progress/Success message (logging)
        _message1 = "Logging (unsaved)...";
        _message2 = "Done!";
        // Suggest next action
        _message3 = "Select (4) to save logged entry.";
        delay.Display3xxxClxWr1xWaLxWr2xWaSxClxWr3xWaSxNl(_message1, _message2, _message3);
    }

    // 4) Save
    public void SaveEntries(){
        // Create a list to store all lines
        List<string> lines = [];

        // Check if there are new entries to save
        if (_newEntries != null){
            // Get file name if undefined
            if (_journalFilePath == null){
                // Receive file name and define property
                Console.Write($"> Enter file name: ");
                string journalFileName = Console.ReadLine();
                _journalFilePath = journalFileName;
            }

            // Check if list `entries` is empty
            if  (_entries != null){
                // Loop through each existing entry and format it as a line of text separated by '~'
                foreach (Entry existingEntries in _entries){
                    string content = $"{existingEntries._entryDate} ~ {existingEntries. _randomPrompt} ~ {existingEntries._response}";
                    lines.Add(content);
                }
            }
            else{
                string [] existingEntries = File.ReadAllLines(_journalFilePath);
                foreach (string line in existingEntries){
                    lines.Add(line);
                }
            }

            // Loop through each new entry and format it as a line of text separated by '~'
            foreach (Entry newEntries in _newEntries){
                string content = $"{newEntries._entryDate} ~ {newEntries._randomPrompt} ~ {newEntries._response}";
                lines.Add(content);
            }
        }

        // Check if there are any lines to save.
        if (lines.Count == 0){
            // Error message (no new entries)
            _message1 = "Error: There are no entries to save.";
            // Suggest next action
            _message2 = "Select (3) to write a new entry.";
            delay.DisplayErr2xxxClxWrxWaLxD1xClxWr1xNlxWaS(_message1, _message2);
        }
        else{
            // Write all lines to the file at once (save funciton)
            File.WriteAllLines(_journalFilePath, lines);
            // Progress/Success message (saving)
            _message1 = "Saving...";
            _message2 ="Done!";
            delay.Display2xxxClxWr1xWaLxWr2xWaSxCl(_message1, _message2);

            // Set bool to True
            _reloading = true;
            // Reload journal (including saved entries)
            LoadEntries();
        }
    }
}










/* ORIGINAL CODE: Journal.cs


// AUTHOR: Andrew Seaman


using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

public class Journal
{
    public Dictionary<int, string> _entries { get; private set; }
    public string _journalFilePath;
    public List<string> _allPrompts;
    public List<string> _unusedPrompts;
    public string _randomPrompt;


    // METHODS //

    public void GetUserJournalFilePath(string _currentUserJournalFilePath)
    {
        _journalFilePath = _currentUserJournalFilePath;
    }

    public Journal()
    {
        _entries = LoadEntriesFromCsvFile(_journalFilePath);
    }

     // Method to read the 'Users.csv' file and load the users into a dictionary
    private Dictionary<int, string> LoadEntriesFromCsvFile(string filePath)
    {
        var entries = new Dictionary<int, string>();

        try
        {
            // Read all lines from the file and skip the first line if it contains headers
            var lines = File.ReadAllLines(filePath).Skip(1);

            // Loop through each line and add it to the dictionary
            foreach (var line in lines)
            {
                // Split the line by the pipe character '|'
                var parts = line.Split('|');

                // Ensure the line has exactly 2 parts: an ID and a name
                if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int userId))
                {
                    string userName = parts[1].Trim();
                    entries[userId] = userName; // Add to the dictionary
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {line}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return entries;
    }

}


*/