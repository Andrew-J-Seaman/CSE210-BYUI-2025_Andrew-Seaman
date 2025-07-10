// AUTHOR: Andrew Seaman
// TITLE: Entry Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

public class Entry
{
    /* >>> ATTRIBUTES - PUBLIC (3) <<< ============================================================
    //  Total: 3
    //
    //      1) _entryDate
    //      2) _randomPrompt
    //      3) _response
    //===========================================================================================*/
    // 1)
    public string _entryDate;

    // 2)
    public string _randomPrompt;

    // 3)
    public string _response;

    /* >>> METHODS - PUBLIC (1) <<< ===============================================================
    //  Total: 1
    //
    //      1) DisplayEntry
    //===========================================================================================*/

    // 1)
    public void DisplayEntry()
    {
        Console.WriteLine(
            $"DATE: {_entryDate}  -  PROMPT: {_randomPrompt}\nRESPONSE: {_response}\n"
        );
    }
}



























/* ORIGINAL CODE: Entry.cs


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
