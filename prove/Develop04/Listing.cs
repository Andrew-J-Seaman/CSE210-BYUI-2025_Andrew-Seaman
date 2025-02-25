using System;

public class Listing : Activity
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   1
    //      CONSTRUCTOR: 1
    //      METHOD:      1
    //  ******************


    // ATTRIBUTE........(1)

    // A1.
    private List<string> _promptsListing;

    // CONSTRUCTOR......(1)

    // C1.
    public Listing(string name, string description, string durationRequestMsg)
        : base(name, description, durationRequestMsg) { } // Pass Name and Description to base class for initialization

    // METHOD...........(1)

    // M1.
    public void RunListing()
    {
        // Introduce activity and set duration
        SetDuration(DisplayPrologue()); // Activity duration = user input (seconds)

        // LISTING functionality:


        // End activity and display summary
        DisplayEpilogue();
    }
}

// REQUIREMENTS
//  •   The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
//  •   The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
//  •   After the starting message, select a random prompt to show the user such as:
//      -   Who are people that you appreciate?
//      -   What are personal strengths of yours?
//      -   Who are people that you have helped this week?
//      -   When have you felt the Holy Ghost this month?
//      -   Who are some of your personal heroes?
//  •   After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
//  •   The user lists as many items as they can until they they reach the duration specified by the user at the beginning.
//  •   The activity them displays back the number of items that were entered.
//  •   The activity should conclude with the standard finishing message for all activities.
