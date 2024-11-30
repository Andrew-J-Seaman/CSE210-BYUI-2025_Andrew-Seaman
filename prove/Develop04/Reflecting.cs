using System;

public class Reflecting : Activity
{
//  ******************
//      * SUMMARY*
//
//      ATTRIBUTE:   2
//      CONSTRUCTOR: 1
//      METHOD:      2
//  ******************


// ATTRIBUTE        (2)
    // A1.
    private List<string> _prompts;
    // A2.
    private List<string> _questions;

// CONSTRUCTOR      (1)
    // C1.
    public Reflecting(string name, string description, string durationRequest) : base(name, description, durationRequest){}

// METHOD           (1)
    // M1.
    public void RunReflecting(){
        SetDuration(DisplayStartMessage() * 10); // Question duraiton: 10 sec

        // REFLECTING functionality:
        

        // End activity and display summary
        DisplayEndMessage();
    }

}