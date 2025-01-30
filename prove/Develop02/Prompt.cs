using System.Security.Cryptography;

public class Prompt
{
    /* >>> ATTRIBUTES - Private (3)<<< ============================================================
    //      1) _prompts
    //      2) _promptsFilePath
    //      3) _noPromptsFound
    //
    //===========================================================================================*/
    // 1)
    private List<string> _prompts;

    // 2)
    private const string _promptsFilePath = "Data/Prompts/prompts.txt";

    // 3)
    private bool _noPromptsFound = false;

    /* >>> METHODS - PUBLIC <<< ===================================================================
    //
    //      1) GetPromptsFilePath
    //      2) PromptGenerator
    //      3) GetNoPromptsFound
    //
    //===========================================================================================*/
    // 1) Return prompts file path
    public string GetPromptsFilePath()
    {
        return _promptsFilePath;
    }

    // 2) Populate prompts list from `prompts.txt`
    public string PromptGenerator()
    {
        //List of prompts
        _prompts = new List<string>();

        string[] lines = File.ReadAllLines(_promptsFilePath);
        foreach (string line in lines)
        {
            _prompts.Add(line);
        }

        // Error handling
        if (_prompts == null)
        {
            _noPromptsFound = true;
            return null;
        }
        else
        {
            //Random generator
            Random random = new Random();
            int randomListItem = random.Next(_prompts.Count);

            //Return prompt (string)
            string randomPrompt = _prompts[randomListItem];
            return randomPrompt;
        }
    }

    // 3) No prompts found
    public bool GetNoPromptsFound()
    {
        return _noPromptsFound;
    }
}










/* ORIGINAL CODE: Prompt.cs


// AUTHOR: Andrew Seaman


public class Prompt
{
    public string _promptsFilePath;
    public Dictionary<int, Tuple<int, string>> _prompts { get; private set; }
    public string _givenPrompt;
    

    // Receive file path in main from User class
    public void GetUserPromptsFilePaths(string _currentUserPromptsFilePath)
    {
        _promptsFilePath = _currentUserPromptsFilePath;
    }

    // Constructor to initialize the prompts dictionary
    public Prompt()
    {
        _prompts = LoadPromptsFromCsvFile(_promptsFilePath);
    }

    // Method to read the 'Prompts.csv' file and load the prompts into a dictionary
    private Dictionary<int, Tuple<int, string>> LoadPromptsFromCsvFile(string filePath)
    {
        _prompts = new Dictionary<int, Tuple<int, string>>();

        try
        {
            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length == 3 && int.TryParse(parts[0].Trim(), out int promptId))
                {
                    int used = int.Parse(parts[1].Trim());
                    string prompt = parts[2].Trim();

                    // Use a Tuple to store 'used' and 'prompt'
                    _prompts[promptId] = Tuple.Create(used, prompt);
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

        return _prompts;
    }

public string SelectPrompt()
{
    // Create a new dictionary to store unused prompts
    Dictionary<int, Tuple<int, string>> unusedPrompts = new Dictionary<int, Tuple<int, string>>();

    // Iterate through the _prompts dictionary
    foreach (KeyValuePair<int, Tuple<int, string>> kvp in _prompts)
    {
        // Check if the 'used' value (Item1) is 0
        if (kvp.Value.Item1 == 0)
        {
            // Add the unused prompt to the unusedPrompts dictionary
            unusedPrompts.Add(kvp.Key, kvp.Value);
        }
    }

    // Here you can decide how to return a prompt from unusedPrompts
    // For example, you could randomly select one or just return the first one
    if (unusedPrompts.Count > 0)
    {
        // Return the first unused prompt's text (Item2)
        return unusedPrompts.Values.First().Item2;
    }
    else
    {
        return "No unused prompts available.";
    }
}

}


*/
