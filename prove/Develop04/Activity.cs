using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

public class Activity
{
//  ******************
//      * SUMMARY*
//
//      ATTRIBUTE:   4
//      CONSTRUCTOR: 1
//      METHOD:      5
//  ******************


// ATTRIBUTE        (4)
    // A1.
    private int _duration;
    // A2.
    private string _name;
    // A3.
    private string _description;
    // A4.
    private string _durationRequest;

// CONSTRUCTOR      (1)
    // C1.
    public Activity(string name, string description, string durationRequest){
        // PURPOSE: Take input for `name` and `description` (from Program class) to initialize relevant activity object.
        
        _name = name;
        _description = description;
        _durationRequest = durationRequest;
    }

// METHOD           (5)
    // M1.
    public int DisplayStartMessage(){
        // PURPOSE: Each activity should start with a common starting message that provides the name of the activity, a description, and asks for and sets the duration of the activity in seconds. Then, it should tell the user to prepare to begin and pause for several seconds.

        // Name: So the user knows which activity they're doing
        Console.Clear();
        Console.WriteLine($"The {_name} activity will begin shortly");
        Spinner(1);

        // Description: So the user understands the activity before they begin
        Console.Clear();                                                              Thread.Sleep(300);
        string star_bar = new string('*', _name.Length + 4);
        Console.WriteLine($"{star_bar}\n> {_name.ToUpper()} <\n{star_bar}\n");    Thread.Sleep(300);
        Console.WriteLine($"Description:\n   > {_description}\n");                    Thread.Sleep(300);
        PressEnterToContinue();
        Spinner(1);

        // Request Duration: so the user can set the activity length
        int duration_value;
        bool isInt = false;
        do{
            Console.Write($"{_durationRequest} ");

            if (int.TryParse(Console.ReadLine().Trim(), out duration_value)){
                isInt = true; // Exit loop
             }
            else{
                Console.WriteLine("Invalid entry. A number is required.");
            }
        } while (!isInt);

        return duration_value;
    }
    // M2.
    public void DisplayEndMessage(){
        // PURPOSE: Each activity should end with a common ending message that tells the user they have done a good job, and pause and then tell them the activity they have completed and the length of time and then pause for several seconds before finishing.

        // Tell user good job
        Console.WriteLine($"Good job!");
        Spinner(3);
        Console.WriteLine($"You've completed a {_name} activity which lasted {_duration} seconds.");
        Spinner(3);
    }
    // M3.
    public void Spinner(int spinDuration){
        // PURPOSE: Whenever the application pauses it should show some kind of animation to the user, such as a spinner, a countdown timer, or periods being displayed to the screen.

        string[] sequence = { ".", "..", "...", " ..", " ." };
        DateTime end = DateTime.Now.AddSeconds(spinDuration);

        while (DateTime.Now < end)
        {
            foreach (string frame in sequence)
            {
                Console.Write($"\r{frame}   ");
                Thread.Sleep(200);
            }
        }
        Console.Write("\r          \r"); // Clear the line

    }
    // M4.
    public void SetDuration(int duration){
        // PURPOSE: set duration from user input

        _duration = duration;
    }
    // M5.
    public void GenerateRndmNum(){
        // PURPOSE: generate a random number for prompt and/or question selection.

        Random random = new Random();
        int randomNumber = random.Next();
    }
    // M6.
    public void PressEnterToContinue(){
        string press_enter = "(Press ENTER to continue)";
        int length = press_enter.Length;
        Console.Write(press_enter);
        Console.ReadLine();

        // Clear the line by resetting cursor position and overwriting with spaces
        Console.SetCursorPosition(0, Console.CursorTop - 1); // Move cursor to the line where `press_enter` was written
        Console.Write(new string(' ', length));  // Overwrite with spaces
        Console.SetCursorPosition(0, Console.CursorTop);    // Reset cursor to the beginning of the current line
    }
}