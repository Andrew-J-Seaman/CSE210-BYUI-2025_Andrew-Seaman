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


// ATTRIBUTE        (1)
    // A1.
    private List<string> _promptsListing;

// CONSTRUCTOR      (1)
    // C1.
    public Listing(string name, string description, string durationRequest) : base(name, description, durationRequest){}

// METHOD           (1)
    // M1.
    public void RunListing(){
        // Introduce activity and set duration
        SetDuration(DisplayStartMessage()); // Activity duration = user input (seconds)

        // LISTING functionality:
        

        // End activity and display summary
        DisplayEndMessage();
    }
}