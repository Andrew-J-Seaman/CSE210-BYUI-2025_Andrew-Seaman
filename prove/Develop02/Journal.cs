// AUTHOR: Andrew Seaman
// TITLE: Journal Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

using System;

public class Journal
{





/* >>> ATTRIBUTES (7) <<< ==================
//
//      1) _entries
//      2) _newEntries
//      3) _journalFilePath
//      4) _fileDictionary
//      5) _directoryPath
//      6) _message1
//      7) _message2
//      8) _message3
//      9) _reloading
//
//========================================*/
    // 1)
    private List<Entry> _entries;
    // 2)
    private List<Entry> _newEntries;
    // 3)
    private string _journalFilePath;
    // 4) Dictionary to store file names and paths
    private Dictionary<int, string> _fileDictionary;
    // 5) Directory to scan for journal files
    private readonly string _directoryPath = "Data/Journal/Journals";
    // 6)
    private string _message1;
    // 7)
    private string _message2;
    // 8)
    private string _message3;
    // 9)
    private bool _reloading;





/* >>> CONSTRUCTOR (1) <<< =================
//
//      1) Jounral
//          -   _fileDictionary
//
==========================================*/
    public Journal()
    {
        // Initialize the dictionary by calling the private method
        _fileDictionary = InitializeFileDictionary();

    }





/* >>> INSTANCES (1) <<< ===================
//
//      1) Delay
//
//========================================*/
    Delay delay = new Delay();





/* >>> PRIVATE METHODS (2) <<< =============
//
//      1) InitializeFileDictionary
//      2) DisplayFilesAndSelect
//
==========================================*/
    // 1) Create the dictionary of files
    private Dictionary<int, string> InitializeFileDictionary()
    {
        Dictionary<int, string> fileDictionary = new Dictionary<int, string>();

        // Check if the directory exists
        if (!Directory.Exists(_directoryPath))
        {
            Console.WriteLine($"The directory '{_directoryPath}' does not exists.");
            return fileDictionary; // Return an empty dictionary
        }

        // Get all files in the directory
        string[] files = Directory.GetFiles(_directoryPath);

        // Populate the dictionary with file names and paths
        fileDictionary[0] = "New journal"; // Add the "New journal" entry as the first option
        for (int i = 0; i < files.Length; i++) // Iterate through all files
        {
            fileDictionary[i + 1] = files[i]; // Add each file to the dictionary with a 1-based index
        }

        return fileDictionary;
    }

    // 2) Display files and allow user selection
    private void DisplayFilesAndSelect()
    {
        // Display files with indices
        Console.Clear();
        Console.WriteLine("Available files:");
        Console.WriteLine("==================");
        foreach (KeyValuePair<int, string> kvp in _fileDictionary)
        {
            Console.WriteLine($"{kvp.Key}. {Path.GetFileName(kvp.Value)}");
        }

        // Prompt the user to select a file
        Console.Write("\n> Select a number: ");
        if (int.TryParse(Console.ReadLine(), out int selectedIndex) &&
        _fileDictionary.ContainsKey(selectedIndex))
        {
            if(_fileDictionary.Count == 0 | selectedIndex == 0)
            {
                Console.Write("> New journal name:"); // Ask for new file name
                string fileName = Console.ReadLine().Trim();
                CreateNewJournalFile(fileName); // Create new journal file

                Console.WriteLine($"> You selected: {fileName}");
                // Construct the full file path
                _journalFilePath = Path.Combine(_directoryPath, fileName);
            }
            else
            {
                Console.WriteLine($"> You selected: {_fileDictionary[selectedIndex]}");
                _journalFilePath = _fileDictionary[selectedIndex];
            }
        }
        else
        {
            Console.WriteLine("> Invalid selection.");
        }
    }





/* >>> PUBLIC METHODS (4) <<< ==============
//
//  > MENU Options:
//
//      1) Load:        LoadEntries
//      2) Display:     DisplayEntries
//      3) Write:       WriteEntry
//      4) Save:        SaveEntries    
//
//  > Additional:
//
//      5) CreateNewJournalFile
==========================================*/

    // 1) Load journal entries
    public void LoadEntries()
    {
        // Get file name if undefined
        DisplayFilesAndSelect();

        // Read all lines from journal file
        string[] lines = File.ReadAllLines(_journalFilePath);

        // Loop through each line
        foreach (string line in lines){
            // Split the line by the '~' character
            string[] parts = line.Split('~');

            // Ensure there are exactly three parts (for entryDate, randomPrompt, response)
            if (parts.Length == 3)
            {
                Entry entry = new Entry(); // Create a new Entry object and set its properties
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
            else
            {
                Console.WriteLine($"Invalid line format: {line}");
            }
        }

        // Progress/Success message (Loading/Reloading)
        if (_reloading == true){
            _message1 = "Reloading...";
        }
        else
        {
            _message1 = "Loading...";
        }

        _message2 = "Done!";
        // Suggest next action
        _message3 = "Select (2) to display the journal or (3) to write a new entry.";

        delay.Display3(_message1, _message2, _message3);
        // Set bool to False
        _reloading = false;
    }

    // 1) Display all entries (saved and unsaved)
    public void DisplayEntries()
    {
        if (_entries == null)
        {
            // Error message (no entries found)
            _message1 = "No entries found.";
            // Suggest next action
            _message2 = "Select (1) to load a journal.";
            delay.DisplayErr2(_message1, _message2);
        }
        else
        {
            // Progress message (displaying)
            _message1 = "Displaying...";
            _message2 ="Done!";
            delay.Display2(_message1, _message2);

            // Print out entries
            foreach(Entry entry in _entries){
                entry.DisplayEntry();
            }
        }
    }

    // 3) Write new entry
    public void WriteEntry()
    {
        // New Prompt object
        Prompt prompt = new Prompt();

        // Verify prompts file path exists
        string promptsFilePath = prompt.GetPromptsFilePath();

        if (!File.Exists(promptsFilePath)){
            Console.WriteLine($"Error: Prompts file not found at {promptsFilePath}");
            return;
        }
        else{

            // Create a new Entry object
            Entry newEntry = new Entry();

            // Get date. Save property
            newEntry._entryDate = DateTime.Today.ToString("d");
            // Get random prompt. Save property
            newEntry._randomPrompt = prompt.PromptGenerator();

            // Progress/Success message (generating prompt)
            _message1 = "Generating prompt...";
            _message2 ="Done!";
            delay.Display2(_message1, _message2);
            // Greeting message
            _message1 = "Let's write! Press (RETURN/ENTER) when finished.";
            delay.Display1(_message1);
            
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
            delay.Display3(_message1, _message2, _message3);
        }
    }

    // 4) Save new entries
    public void SaveEntries()
    {
        // Create a list to store all lines
        List<string> lines = [];

        // Check if there are new entries to save
        if (_newEntries != null){
            // Get file name if undefined
            if (_journalFilePath == null){
                DisplayFilesAndSelect();
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
            delay.DisplayErr2(_message1, _message2);
        }
        else
        {
            // Write all lines to the file at once (save funciton)
            File.WriteAllLines(_journalFilePath, lines);
            // Progress/Success message (saving)
            _message1 = "Saving...";
            _message2 ="Done!";
            delay.Display2(_message1, _message2);

            // Set bool to True
            _reloading = true;
            // Reload journal (including saved entries)
            LoadEntries();
        }
    }

    // 5) Create a new journal file
    public void CreateNewJournalFile(string fileName)
    {
        string fileNameFull = fileName + ".txt";
        // Ensure the directory exists
        if (!Directory.Exists(_directoryPath))
        {
            Console.WriteLine($"The directory '{_directoryPath}' does not exist. Creating it...");
            Directory.CreateDirectory(_directoryPath); // Create the directory if it doesn't exist
        }

        // Construct the full file path
        string filePath = Path.Combine(_directoryPath, fileNameFull);
        _journalFilePath = filePath;

        // Check if the file already exists
        if (File.Exists(filePath))
        {
            Console.WriteLine($"A file named '{fileNameFull}' already exists in the directory.");
        }
        else
        {
            // Create the file and write an initial message or leave it empty
            File.WriteAllText(filePath, ""); // Creates an empty file
            Console.WriteLine($"New journal file '{fileNameFull}' created at {_directoryPath}");
        }
    }

} // The End!
























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