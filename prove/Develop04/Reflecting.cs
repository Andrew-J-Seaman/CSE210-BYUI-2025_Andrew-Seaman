using System;

public class Reflection : Activity
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   2
    //      CONSTRUCTOR: 1
    //      METHOD:      1
    //  ******************


    // ATTRIBUTE........(2)

    // A1.
    private List<string> _promptsReflecting;

    // A2.
    private List<string> _questions;

    // CONSTRUCTOR......(1)

    // C1.
    public Reflection(string name, string description, string durationRequestMsg)
        : base(name, description, durationRequestMsg) // Pass Name and Description to base class for initialization
    {
        // Initialize prompts
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
            "Think of a time when you put someone else’s needs before your own.",
        };

        // Initialize questions
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
            "What value does this memory hold for your future?",
        };
    }

    // METHOD...........(1)

    // M1.
    public void RunReflection()
    {
        SetDuration(DisplayPrologue() * 10); // Question duraiton: 10 sec

        // REFLECTION functionality:


        // End activity and display summary
        DisplayEpilogue();
    }
}

// REQUIREMENTS
//  •   The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
//  •   The description of this activity should be something like: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
//  •   After the starting message, select a random prompt to show the user such as:
//      -   Think of a time when you stood up for someone else.
//      -   Think of a time when you did something really difficult.
//      -   Think of a time when you helped someone in need.
//      -   Think of a time when you did something truly selfless.
//  •   After displaying the prompt, the program should ask the to reflect on questions that relate to this experience. These questions should be pulled from a list such as the following:
//      -   Why was this experience meaningful to you?
//      -   Have you ever done anything like this before?
//      -   How did you get started?
//      -   How did you feel when it was complete?
//      -   What made this time different than other times when you were not as successful?
//      -   What is your favorite thing about this experience?
//      -   What could you learn from this experience that applies to other situations?
//      -   What did you learn about yourself through this experience?
//      -   How can you keep this experience in mind in the future?
//  •   After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
//  •   It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
//  •   The activity should conclude with the standard finishing message for all activities.
