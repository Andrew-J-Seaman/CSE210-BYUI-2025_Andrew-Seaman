public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public void DisplayEntry()
    {
        Console.WriteLine($"DATE: {_date}  -  PROMPT: {_prompt}\nRESPONSE: {_response}");
    }







}















































/*


// AUTHOR: Andrew Seaman


using System.Xml.Serialization;

public class Entry
{
    // Initialize attributes
    public DateTime _entryDate; // string/DateTime
    public string _entryPrompt;
    public string _entryNew;
    public string _entryTitle;



    // GOAL: get: date, title, prompt, entry; then return Entry instance

    // Initialize methods
    public void writePrompt(string prompt)
    {
        Console.WriteLine($"Prompt: {prompt}");
    }
    
    public void TodayDate()
    {
        _entryDate = DateTime.Now;
    }

    public void WriteEntry()
    {
        // Entry Date




        // Title
        Console.Write("Title this entry: ");
        _entryTitle = Console.ReadLine();
    }

    public void GetTitle()
    {
        Console.Write("Title your entry: ");
        _entryTitle = Console.ReadLine();
    }
}


*/