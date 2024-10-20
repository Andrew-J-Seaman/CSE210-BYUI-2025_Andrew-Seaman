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
    public string CurrentPrompt()
    {
        // New prompt instance
        Prompt newEntryPrompt = new Prompt();
        // Get random int
        Prompt.RandomProducer = newEntryPrompt._randomIndex; //fix

        Prompt._generatePrompt



        //Goal: get random prompt output (string)
        return prompt;
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