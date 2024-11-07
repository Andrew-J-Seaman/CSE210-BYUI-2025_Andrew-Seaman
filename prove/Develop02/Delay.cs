public class Delay
{
    private int _long;
    private int _short;

    // Constructor for delay variable values
    public Delay()
    {
        // Seconds to milliseconds
        _long  = 2 * 1000;
        _short = (int)(1.5 * 1000);
    }

//==================================
    // DELAY methods (reused): 
    //      1) Running
    //      2) ClearDelay
    //      3) Clear
//==================================
    
    // Short or Long delay
    public void Running(int length)
    {
        // Run delay in milliseconds
        Thread.Sleep(length);
    }

    // Clear
    public void Clear()
    {
        Console.Clear();
    }

    // Short delay w/ clearing
    public void ClearDelay(int length)
    {
        Thread.Sleep(length);
        Clear();
    }




//==================================
    // MENU methods: 
    //      1) DisplayMenuSelection
    //      2) 
//==================================

    // 1) DisplayMenuSelection
    public void DelayDisplayMenuSelectionError()
    {
        // Show error message with delay
        Clear();
        Console.WriteLine("Error: Please enter a number between 1 and 5.");
        Running(_short);
    } 

//==================================
    // JOURNAL methods: 
    //      1) LoadEntries
    //      2) DisplayEntries
    //      3) WriteEntry
    //      4) SaveEntries
    //      5) QuitJournal
//==================================

    // 1) LoadEntries
    public void DelayLoadEntriesProgressSuccess(){
        // Show in progess message with delay
        Clear();
        Console.Write("Loading...");
        Running(_long);

        // Show success message with delay and console clearing
        Console.WriteLine("Done!");
        ClearDelay(_short);
    } 


    // 2) DisplayEntries
    public void DelayDisplayEntriesError(){
        // Show error message with delay
        Clear();
        Console.WriteLine("No entries found.");
        Running(_long);
        Clear();

        // Prompt user to load a journal
        Console.WriteLine("Select (1) to load a journal.");
        Running(_short);
    }
    public void DelayDisplayEntriesProgress(){
        // Show in progess message with delay
        Clear();
        Console.Write("Displaying...");
        Running(_long);
        // Show success message with delay and NO console clearing
        Console.WriteLine("Done!");
        Running(_short);
        Clear();
    }

    // 3) WriteEntry
    public void DelayWriteEntryPromptProgressSuccess(){
        // Show in progess message with delay
        Clear();
        Console.Write("Generating prompt...");
        Running(_long);

        // Show success message with delay and console clearing
        Console.WriteLine("Done!");
        ClearDelay(_short);
    }
    public void DelayWriteEntrySuccess(){
        // Show success message with delay and console clearing
        Clear();
        Console.WriteLine("Entry logged (unsaved).");
        ClearDelay(_long);

        Console.WriteLine("Select (4) to save new entries.");
        Running(_short);
    }
    
    // 4) Save Entries
    public void DelaySaveEntriesError(){
        // Show error message with delay
        Clear();
        Console.WriteLine("There are no entries to save.");
        ClearDelay(_short);
        
        // Prompt user to write a new entry
        Console.Write("Select (3) to write a new entry.\n");
        Running(_short);
    }
    public void DelaySaveEntriesProgessSuccess(){
        // Show in progess message with delay
        Clear();
        Console.Write("Saving...");
        Running(_long);

        // Show success message with delay and console clearing
        Console.WriteLine("Done!");
        ClearDelay(_short);
    }

    // 5) Quit Journal
    public void DelayQuitJournalProgressSuccess(){
        // Show in progess message with delay
        Clear();
        Console.Write("Quitting program...");
        Running(_long);
        Console.WriteLine("Done!");
        Running(_short);
        Clear();

        // Show success message with delay
        Console.WriteLine("See you tomorow!");
    }
}