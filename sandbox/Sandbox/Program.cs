/*// MAIN CLASS Logic:

public class Activity
{
    string _startPrompt;
    string _endPrompt;
    protected string _activityName;

    // Constructor initializes the _activityName attribute
    public Activity(string _activityName)
    {
        this._activityName=_activityName;
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
*/



/*
// SPINNER Logic:

using System;
using System.Threading;
using System.Threading.Tasks;

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
*/




 // FADE IN/OUT Logic:

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string message = "Hello, this is a fade-in and fade-out message!";
        
        FadeIn(message);
        Thread.Sleep(1000); // Pause before fading out
        FadeOut(message);
    }

    static void FadeIn(string message)
    {
        Console.Clear();
        for (int i = 1; i <= message.Length; i++)
        {
            Console.Write("\r" + message.Substring(0, i));
            Thread.Sleep(50); // Adjust speed for a slower or faster effect
        }
    }

    static void FadeOut(string message)
    {
        Console.Write("\r" + message);
        Thread.Sleep(500); // Pause briefly before starting fade-out
        
        for (int i = message.Length; i >= 0; i--)
        {
            Console.Write("\r" + message.Substring(0, i) + new string(' ', message.Length - i));
            Thread.Sleep(50); // Adjust speed for a slower or faster effect
        }
    }
}
