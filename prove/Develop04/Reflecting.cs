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
    private List<string> _promptsReflecting;
    // A2.
    private List<string> _questions;

// CONSTRUCTOR      (1)
    // C1.
    public Reflecting(string name, string description, string durationRequest) : base(name, description, durationRequest)
    {
        // Initialize the prompts and questions
        _promptsReflecting = new List<string>
        {
            "Think of a time when you overcame a fear.",
            "Think of a time when you made someone feel truly appreciated.",
            "Think of a time when you worked hard to achieve a goal.",
            "Think of a time when you forgave someone who wronged you.",
            "Think of a time when you went out of your way to support a friend.",
            "Think of a time when you stayed calm under pressure.",
            "Think of a time when you stood up for what you believed in.",
            "Think of a time when you made a positive impact on a community.",
            "Think of a time when you learned something valuable from failure.",
            "Think of a time when you put someone else’s needs before your own."
        };

        _questions = new List<string>
        {
            "Why do you think this experience stood out to you?",
            "What challenges did you face during this experience?",
            "Who else was involved, and how did they contribute?",
            "What emotions did you experience throughout this event?",
            "What surprised you most about this experience?",
            "How would you describe this experience to someone else?",
            "What strengths did you demonstrate during this time?",
            "What would you do differently if you encountered this situation again?",
            "How has this experience shaped your perspective?",
            "What value does this memory hold for your future?"
        };
    }

// METHOD           (1)
    // M1.
    public void RunReflecting(){
        SetDuration(DisplayStartMessage() * 10); // Question duraiton: 10 sec

        // REFLECTING functionality:
        

        // End activity and display summary
        DisplayEndMessage();
    }
}