public class Delay
{
    private int _long;
    private int _short;

    // Constructor for delay variable values
    public Delay()
    {
        // Seconds to milliseconds
        _long  = 3 * 1000;
        _short = (int)(1.5 * 1000);
    }

//==================================
    // DELAY methods (reused): 
    //      1) Running
    //      2) ClearDelay
    //      3) Clear
//==================================
    
    // Long delay
    public void Running()
    {
        // Run delay in milliseconds
        Thread.Sleep(_long);
    }

    // Short delay w/ clearing
    public void ClearDelay()
    {
        Thread.Sleep(_short);
        Console.Clear();
    }

    // Clear no delay
    public void Clear()
    {
        Console.Clear();
    }


//==================================
    // MENU methods: 
    //      1) 
    //      2) 
//==================================



//==================================
    // JOURNAL methods: 
    //      1) LoadEntries
    //      2) DisplayEntries
    //      3) WriteEntry
    //      4) SaveEntries
    //      5) Quit
//==================================

    // 1) LoadEntries
       public void DelayLoadEntriesProgressSuccess()
    {
        // Show in progess message with delay
        Console.WriteLine("\nLoading...");
        Running();

        // Show success message with delay and console clearing
        Console.WriteLine("Loaded.");
        ClearDelay();
    } 


    // 2) DisplayEntries
    public void DelayDisplayEntriesError()
    {
        Clear();
        // Show error message with delay
        Console.WriteLine("\nError: No entries found. Please load a journal.\n");
        Running();
    }
    public void DelayDisplayEntriesProgress()
    {
        // Show in progess message with delay
        Console.WriteLine("\nDisplaying...");
        Running();
        Clear();
    }
    public void DelayDisplayEntriesSuccess()
    {
        // Show success message with delay and NO console clearing
        Console.WriteLine("\nAll entries displayed.\n");
    }


    // 3) WriteEntry
    public void DelayWriteEntryPromptProgressSuccess()
    {
        // Show in progess message with delay
        Console.WriteLine("\nGenerating prompt...");
        Running();

        // Show success message with delay and console clearing
        Console.WriteLine("Prompt generated.");
        ClearDelay();
    }
    public void DelayWriteEntrySuccess()
    {
        // Show success message with delay and console clearing
        Console.WriteLine("\nEntry logged (unsaved).");
        ClearDelay();

        Console.WriteLine("Select (4) to save new entries.");
    }
    
    // 4) Save Entries
    public void DelaySaveEntriesProgessSuccess()
    {
        // Show in progess message with delay
        Console.WriteLine("\nSaving...");
        Running();

        // Show success message with delay and console clearing
        Console.WriteLine("Saved.");
        ClearDelay();
    }
}