public class Prompt
{
    private List<string> _prompts;

    // Populate prompts list (via file or hard coded)
    public string PromptGenerator()
    {
        //List of prompts

        //Random generator

        //Return: prompt : string

        return "";

    }

}
















































/*


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