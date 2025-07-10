using System;
using System.Threading;
using System.Threading.Tasks;

// DISCLAIMER: frankly this program.cs file is a couple of things that belong in either separate classes (files) or projects as they do different things. However they both releate to the same project, so I am leaving them here for now. The first part is the Activity class and its children, which are used in a journal application. The second part is a spinner that can be used to indicate loading or processing states in a console application.


// ——————————————————————————————————————————————————————————————————————————————————————————


// MAIN CLASS Logic (Journal-Develop2):

public class Activity
{
    string _startPrompt;
    string _endPrompt;
    protected string _activityName;

    // Constructor initializes the _activityName attribute
    public Activity(string _activityName)
    {
        this._activityName = _activityName;
    }
    public void DefaultPrompt(string _activityName)
    {
        _startPrompt = ($"Beginning the {_activityName} activity.");
        _endPrompt = ($"Ending the {_activityName} activity.");
    }
}


public class Reflect : Activity // "Something to that effect." - Ammon
{
    // Passes "Reflect" to the parent constructor
    public Reflect() : base("Reflect")
    {
    }

}

public class Breathe : Activity
{
    // Passes "Reflect" to the parent constructor
    public Breathe() : base("Breathe")
    {
    }
}

public class Listing : Activity
{
    // Passes "Reflect" to the parent constructor
    public Listing() : base("Listing")
    {
    }
}


// ——————————————————————————————————————————————————————————————————————————————————————————


// SPINNER Logic:
class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Loading");
        var cancellationTokenSource = new CancellationTokenSource();

        // Start the spinner in a separate task
        var spinnerTask = ShowSpinner(cancellationTokenSource.Token);

        // Simulate some work by waiting
        await Task.Delay(5000);

        // Stop the spinner once the work is done
        cancellationTokenSource.Cancel();
        await spinnerTask;

        Console.WriteLine("\nDone!");
    }

    static async Task ShowSpinner(CancellationToken token)
    {
        var spinnerChars = new[] { '|', '/', '-', '\\' };
        int counter = 0;

        while (!token.IsCancellationRequested)
        {
            // Print the spinner character
            Console.Write($"\b{spinnerChars[counter]}");
            counter = (counter + 1) % spinnerChars.Length;

            // Delay to make the spinner visible
            await Task.Delay(100);
        }
    }
}


// ——————————————————————————————————————————————————————————————————————————————————————————
