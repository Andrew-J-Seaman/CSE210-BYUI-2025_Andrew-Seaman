// AUTHOR: Andrew Seaman
// TITLE: Journal Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

using System;
using System.Formats.Asn1;
using System.Net.Sockets;

public class Journal
{
    /* >>> ATTRIBUTES (8) <<< ==================
    //
    //      1) _savedEntries
    //      2) _unsavedEntries
    //      3) _journalFilePath
    //      4) _fileDictionary
    //      5) _directoryPath
    //      6) _message1
    //      7) _message2
    //      8) _message3
    //
    //========================================*/
    // 1)
    private List<Entry> _savedEntries;

    // 2)
    private List<Entry> _unsavedEntries;

    // 3)
    private string _journalFilePath;

    // 4) Dictionary to store file names and paths
    private Dictionary<int, string> _fileDictionary;

    // 5) Directory to scan for journal files
    private readonly string _directoryPath = "Data/Journals/";

    // 6)
    private string _message1;

    // 7)
    private string _message2;

    // 8)
    private string _message3;

    /* >>> INSTANCES (1) <<< ===================
    //
    //      1) Delay
    //
    //========================================*/
    // 1)
    Delay delay = new Delay();

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

    /* >>> PRIVATE METHODS (2) <<< =============
    //
    //      1) InitializeFileDictionary
    //      2) DisplayFilesAndSelect
    //      3) ClearLastLine
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
        for (int i = 0; i < files.Length; i++) // Iterate through all files
        {
            fileDictionary[i + 1] = files[i]; // Add each file to the dictionary with a 1-based index
        }
        fileDictionary[0] = "New journal?"; // Add the "New journal" entry as the LAST option

        return fileDictionary;
    }

    // 2) Display files and allow user selection
    private void DisplayFilesAndSelect()
    {
        // If a journal is already loaded give the user the choice to use it.
        bool loadDiffJournal = true;
        if (_journalFilePath != null)
        {
            string response = "";
            bool validResponse = false; // Validity boolean
            while (validResponse == false)
            {
                Console.Clear();
                Console.Write($"> Use loaded journal `{Path.GetFileName(_journalFilePath)}` (Y/N)? ");
                response = Console.ReadLine().Trim().ToUpper();

                if (response == "Y" || response == "N") // Error handling
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("> Invalid response."); // Error message
                    Thread.Sleep(500);
                }
            }

            if (response == "Y")
            {
                loadDiffJournal = false;
            }
        }

        // If no journal is already loaded have the user load or create one.
        if (loadDiffJournal == true)
        {
            // Loading text
            Console.Clear();
            _message1 = "Collecting journals...";
            _message2 = "Done!";
            delay.Display2(_message1, _message2);

            // Display files with indices
            Console.WriteLine("Available journals:");
            Console.WriteLine("==================");
            foreach (KeyValuePair<int, string> kvp in _fileDictionary)
            {
                Console.WriteLine($"{kvp.Key}. {Path.GetFileName(kvp.Value)}"); // File names
            }

            bool validSelectedIntKey = false;
            do
            {
                // Prompt user to select a file (i.e. journal).
                Console.Write("\n> Enter a number: ");
                if (
                    int.TryParse(Console.ReadLine(), out int selectedIntKey)
                    && _fileDictionary.ContainsKey(selectedIntKey)
                )
                {
                    validSelectedIntKey = true; // Change bool value to exit loop
                    ClearLastLine(); // Clear number selection

                    if (selectedIntKey == 0)
                    {
                        Console.Write("> New journal name: "); // Ask for new file name
                        string fileName = Console.ReadLine().Trim();
                        CreateNewJournalFile(fileName); // Create new journal file
                    }
                    else
                    {
                        Console.WriteLine($"> You selected: {_fileDictionary[selectedIntKey]}");
                        _journalFilePath = _fileDictionary[selectedIntKey]; // Define journal file path
                    }
                }
                else
                {
                    // Error message
                    ClearLastLine(); // Clear menu selection
                    Console.Write("> Invalid selection!");
                    Thread.Sleep(1000);
                    ClearLastLine(); // Clear error message
                }
            } while (!validSelectedIntKey);
        }
    }

    // 3)
    private void ClearLastLine()
    {
        if (Console.CursorTop > 0) // Ensure we don't move above the top line
        {
            Console.SetCursorPosition(0, Console.CursorTop); // Move to the previous line
            Console.Write(new string(' ', Console.BufferWidth)); // Clear the line completely
            Console.SetCursorPosition(0, Console.CursorTop - 1); // Reset cursor to the beginning of cleared line
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
        DisplayFilesAndSelect(); // Ensure a file is selected

        if (string.IsNullOrEmpty(_journalFilePath))
        {
            Console.WriteLine("Error: No file selected.");
            return;
        }

        if (!File.Exists(_journalFilePath))
        {
            Console.WriteLine($"Error: The file '{_journalFilePath}' does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(_journalFilePath); // Read file safely

        foreach (string line in lines)
        {
            string[] parts = line.Split('~');

            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._entryDate = parts[0].Trim();
                entry._randomPrompt = parts[1].Trim();
                entry._response = parts[2].Trim();

                if (_savedEntries == null)
                {
                    _savedEntries = new List<Entry>();
                }
                _savedEntries.Add(entry);
            }
            else
            {
                Console.WriteLine($"Invalid line format: {line}");
            }
        }

        // Success message
        _message1 = "Loading...";
        _message2 = "Done!";
        _message3 = "Select (2) to display a journal or (3) to write a new entry.";
        delay.Display3(_message1, _message2, _message3);
    }
    // 2) Display all entries (saved and unsaved)
    public void DisplayEntries()
    {
        if (_savedEntries == null && _unsavedEntries == null)
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
            _message2 = "Done!";
            delay.Display2(_message1, _message2);

            string separator = new string('=', 100);

            if (_savedEntries != null && _savedEntries.Count() > 0)
            {
                Console.WriteLine($"{separator}\nSAVED ENTRIES\n{separator}");

                // Print out entries
                foreach (Entry entry in _savedEntries)
                {
                    entry.DisplayEntry();
                }
            }
            if (_unsavedEntries != null && _unsavedEntries.Count() > 0)
            {
                Console.WriteLine($"{separator}\nUNSAVED ENTRIES\n{separator}");

                // Print out entries
                foreach (Entry entry in _unsavedEntries)
                {
                    entry.DisplayEntry();
                }
            }

            Thread.Sleep(500);
            Console.WriteLine("\n\n\nNOTE: Scroll up to see earliest entries.");
            Thread.Sleep(500);
            Console.Write("Press (ENTER / RETURN) to exit."); // Return to main menu
            Console.ReadLine(); // Await input (ENTER)
            Console.Clear();
        }
    }

    // 3) Write new entry
    public void WriteEntry()
    {
        ////////// >>>>>>> ADDITION <<<<<<<
        /// - use public method from Prompts class `GetNoPromptsFound` to either continue writing entry or break the method.





        Prompt prompt = new Prompt(); // New Prompt object

        // Verify prompts file path exists
        string promptsFilePath = prompt.GetPromptsFilePath();

        if (!File.Exists(promptsFilePath))
        {
            Console.WriteLine($"Error: Prompts file not found at {promptsFilePath}");
            return;
        }
        else
        {
            // Create a new Entry object
            Entry newEntry = new Entry();

            // Get date. Save property
            newEntry._entryDate = DateTime.Today.ToString("d");
            // Get random prompt. Save property
            newEntry._randomPrompt = prompt.PromptGenerator();

            // Progress/Success message (generating prompt)
            _message1 = "Generating prompt...";
            _message2 = "Done!";
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
            if (_unsavedEntries == null)
            {
                _unsavedEntries = new List<Entry> { newEntry };
            }
            else
            {
                _unsavedEntries.Add(newEntry);
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
        if (_unsavedEntries.Count() > 0)
        {
            // User selects journal file name to save unsaved etries to.
            DisplayFilesAndSelect();

            // Add existing entries from
            string[] existingEntries = File.ReadAllLines(_journalFilePath);
            foreach (string line in existingEntries)
            {
                lines.Add(line);
            }

            // Loop through each new entry and format it as a line of text separated by '~'
            foreach (Entry newEntries in _unsavedEntries)
            {
                string content =
                    $"{newEntries._entryDate} ~ {newEntries._randomPrompt} ~ {newEntries._response}";
                lines.Add(content);
            }

            // (SAVE) Overwrite the file
            File.WriteAllLines(_journalFilePath, lines);

            // Reinitialize `_unsavedEntries` only after successful write (i.e. wipe the list).
            _unsavedEntries = new List<Entry>();

            // Success message
            _message1 = "Saving...";
            _message2 = "Done!";
            delay.Display2(_message1, _message2);
        }
        else
        {
            // Error message & suggestion
            _message1 = "Error: no unsaved entries.";
            _message2 = "Select (3) to write a new entry.";
            delay.DisplayErr2(_message1, _message2);
        }
    }

    // 5) Create a new journal file
    public void CreateNewJournalFile(string fileName)
    {
        string fileNameFull = fileName.EndsWith(".txt") ? fileName : fileName + ".txt"; // Ensure .txt extension

        // Ensure the directory exists
        if (!Directory.Exists(_directoryPath))
        {
            _message1 = $"The directory '{_directoryPath}' does not exist.";
            _message2 = $"Creating it...";
            _message3 = $"Done!";
            Directory.CreateDirectory(_directoryPath); // Create the directory if it doesn't exist
            delay.Display3(_message1, _message2, _message3);
        }

        // Construct the full file path
        _journalFilePath = Path.Combine(_directoryPath, fileNameFull);

        // Check if the file already exists
        if (File.Exists(_journalFilePath))
        {
            Console.WriteLine($"A file named '{fileNameFull}' already exists in the directory.");
        }
        else
        {
            // Create the file using UTF-8 encoding to ensure it's recognized correctly as a text file
            File.WriteAllText(_journalFilePath, "", System.Text.Encoding.UTF8);
            Directory.GetFiles(_directoryPath); // Refresh directory listing
            Console.WriteLine($"New journal file '{fileNameFull}' created at {_directoryPath}");

            // Delay text
            _message1 = "Creating journal...";
            _message2 = "Done!";
            delay.Display2(_message1, _message2);
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
    public Dictionary<int, string> _savedEntries { get; private set; }
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
        _savedEntries = LoadEntriesFromCsvFile(_journalFilePath);
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
