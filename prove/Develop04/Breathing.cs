using System;

public class Breathing : Activity
{
//  ******************
//      * SUMMARY*
//
//      ATTRIBUTE:   0
//      CONSTRUCTOR: 1
//      METHOD:      1
//  ******************


// ATTRIBUTE        (0)

// CONSTRUCTOR      (1)
    // C1.
    public Breathing(string name, string description, string durationRequest) : base(name, description, durationRequest){}
    
// METHOD           (1)
    // M1.
    public void RunBreathing(){
        SetDuration(DisplayStartMessage() * 10); // Breathing Interval (10 sec): Inhale: 5, Hold: 2, Exhale: 3

        // BREATHING functionality:
        

        // End activity and display summary
        DisplayEndMessage();
    }
}