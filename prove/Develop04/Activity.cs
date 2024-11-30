using System;

public class Activity
{
//  ******************
//      * SUMMARY*
//
//      ATTRIBUTE:   3
//      CONSTRUCTOR: 1
//      METHOD:      5
//  ******************


// ATTRIBUTE        (3)
    // A1.
    private int _duration;
    // A2.
    private string _name;
    // A3.
    private string _description;

// CONSTRUCTOR      (1)
    // C1.
    public Activity(string name, string description){
        // PURPOSE: Take input for `name` and `description` (from Program class) to initialize relevant activity object.
        
        name = _name;
        description = _description;
    }

// METHOD           (5)
    // M1.
    public void DisplayStartMessage(){
        // PURPOSE: Each activity should start with a common starting message that provides the name of the activity, a description, and asks for and sets the duration of the activity in seconds. Then, it should tell the user to prepare to begin and pause for several seconds.

        // Name: So the user knows which activity they're doing
        Console.WriteLine($"The {_name} activity will begin shortly.");
        // Description: So the user understands the activity before they begin
        Console.WriteLine($"Please read the description below:\n\t> {_description}");
        Console.WriteLine("\nPress enter to continue.");
        Console.ReadLine();
        // Duration: so the user can set the activity length
        bool B = false;
        bool R = false;
        bool L = false;
        string text_insert = "";
        if (_name == "Breathing"){
            text_insert = "number of breathing intervals (10 sec)";
            B = true;
        }
        else if (_name == "Reflecting"){
            text_insert = "duration alloted to answer questions";
            R = true;
        }
        else if (_name == "Listing"){
            text_insert = "activity duration";
            L = true;
        }
        
        Console.WriteLine($"\nSpecify the {text_insert}: ");
        
    }
    // M2.
    public void DisplayEndMessage(){
        // PURPOSE: Each activity should end with a common ending message that tells the user they have done a good job, and pause and then tell them the activity they have completed and the length of time and pauses for several seconds before finishing.

        Console.WriteLine($"");

    }
    // M3.
    public void Spinner(int spinDuration){
        // PURPOSE: Whenever the application pauses it should show some kind of animation to the user, such as a spinner, a countdown timer, or periods being displayed to the screen.


    }
    // M4.
    public void SetDuration(int duration){
        // PURPOSE: set duration from user input

        _duration = duration;
    }
    // M5.
    public void GenerateRndmNum(){
        // PURPOSE: 


    }
}