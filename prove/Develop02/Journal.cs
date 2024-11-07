using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System;


public class Journal{
    private List<Entry> _entries;
    private string _journalFilePath;

    Delay delay = new Delay();

//=========================================
    // MENU options (relevant to JOURNAL):
    //      1) Load
    //      2) Display
    //      3) Write
    //      4) Save
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
                    _entries = new List<Entry>();
                }
                _entries.Add(entry);
            }
            else{
                Console.WriteLine($"Invalid line format: {line}");
            }
        }
        delay.DelayLoadEntriesProgressSuccess();
    }

    // 2) Display
    public void DisplayEntries(){
        if (_entries == null){
            delay.DelayDisplayEntriesError();
        }
        else{
            foreach(Entry entry in _entries){
                // Display all parts of each entry on a new line >>> Go into entry and finish writing this function.
                delay.DelayDisplayEntriesProgress();
                entry.DisplayEntry();
                delay.DelayDisplayEntriesSuccess();
            }
        }
    }

    // 3) Write
    public void WriteEntry(){
        // Greeting message
        Console.WriteLine("\nLet's write!");

        // New Prompt object
        Prompt prompt = new Prompt();

        // Create a new Entry object
        Entry newEntry = new Entry();

        // Get date. Save property
        newEntry._entryDate = DateTime.Today.ToString("d");
        // Get random prompt. Save property
        newEntry._randomPrompt = prompt.PromptGenerator();

        // Display Prompt
        delay.DelayWriteEntryPromptProgressSuccess();
        Console.WriteLine($"\nPrompt: {newEntry._randomPrompt}");

        // Get user response. Save property
        Console.Write("> Response: ");
        newEntry._response = Console.ReadLine();

        // Add newEntry to `_entries`
        if (_entries == null){
            _entries = new List<Entry>();
        }
        _entries.Add(newEntry); 
        delay.DelayWriteEntrySuccess();
    }

    // 4) Save
    public void SaveEntries(){
        // Greeting message
        

        // Create a list to store all lines
        List<string> lines = new List<string>();

        // Loop through each entry and format it as a line of text
        foreach (Entry existingEntry in _entries){
            string content = $"{existingEntry._entryDate} ~ {existingEntry._randomPrompt} ~ {existingEntry._response}";
            lines.Add(content);
        }

        // Get file name if undefined
        if (_journalFilePath == null){
            Console.Write($"> Enter file name: ");
            string journalFileName = Console.ReadLine();
            _journalFilePath = journalFileName;
        }
        // Write all lines to the file at once
        File.WriteAllLines(_journalFilePath, lines);
        delay.DelaySaveEntriesProgessSuccess();
    }
}
















































/*


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