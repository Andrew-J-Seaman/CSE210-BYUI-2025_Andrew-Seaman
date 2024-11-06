public class Journal
{
    private List<Entry> _entries;


    // Menu option: 1
    public void LoadEntries()
    {
        //Read entries from a txt/csv file and add them to the entries list

    }

    // Menu option: 2
    public void DisplayEntries()
    {
        foreach(Entry entry in _entries)
        {
            // Display all parts of each entry on a new line >>> Go into entry and finish writing this function.
           entry.DisplayEntry();
        }
    }

    // Menu option: 3
    public void WriteEntry()
    {
        // Greeting
        Console.WriteLine("Let's write!\n");

        // Prompt

           // string prompt = prompt.PromptGenerator();

           // Console.WriteLine(prompt);

       // Add entry to `_entries`
        Console.WriteLine("Entry: ");
    }

    // Menu option: 4
    public void SaveEntries()

    {
        //Save all entries to the txt/csv file.

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