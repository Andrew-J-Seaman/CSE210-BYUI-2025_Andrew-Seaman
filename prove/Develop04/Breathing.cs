using System;

public class Breathing : Activity
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   0
    //      INSTANCE:    1
    //      CONSTRUCTOR: 1
    //      METHOD:      1
    //  ******************


    // ATTRIBUTE........(0)

    // INSTANCES........(1)

    // I1.
    Spinner spinner = new Spinner();

    // CONSTRUCTOR......(1)

    // C1.
    public Breathing(string name, string description, string durationRequestMsg)
        : base(name, description, durationRequestMsg) { } // Pass Name and Description to base class for initialization

    // METHOD...........(1)

    // M1.
    public void RunBreathing()
    {
        SetDuration(DisplayPrologue()); // Breathing Intervals (10 sec): Inhale: 5, Exhale: 5.
        Console.Clear();

        string msg1 = "Breathe in ";
        string msg2 = "Breathe out ";

        // BREATHING functionality:
        for (int i = 0; i < _duration; i++)
        {
            Console.Write($"Question {i + 1}.");
            spinner.CountUpDown(msg1, msg2);
            Console.WriteLine("");
        }

        // Correct duration (intervals = 10 sec each)
        _duration = _duration * 10;

        // End activity and display summary
        DisplayEpilogue();
    }
}

// REQUIREMENTS
//  • √ The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
//  • √ The description of this activity should be something like: "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
//  •   After the starting message, the user is shown a series of messages alternating between "Breathe in..." and "Breathe out..."
//  •   After each message, the program should pause for several seconds and show a countdown.
//  •   It should continue until it has reached the number of seconds the user specified for the duration.
//  •   The activity should conclude with the standard finishing message for all activities.
