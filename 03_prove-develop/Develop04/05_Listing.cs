//**********************************
// PROJECT: Mindfullness (Develop04)
//**********************************

using System;

/* REQUIREMENTS____________________________________________________________________________________
 •   The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
 •   The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
 •   After the starting message, select a random prompt to show the user such as:
     -   Who are people that you appreciate?
     -   What are personal strengths of yours?
     -   Who are people that you have helped this week?
     -   When have you felt the Holy Ghost this month?
     -   Who are some of your personal heroes?
 •   After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
 •   The user lists as many items as they can until they they reach the duration specified by the user at the beginning.
 •   The activity them displays back the number of items that were entered.
 •   The activity should conclude with the standard finishing message for all activities.

PROGRESS:
———————————————————
| Task | Complete |
|------|----------|
|  1   |    Yes   |
|  2   |    Yes   |
|  3   |    Yes   |
|  4   |    Yes   |
|  5   |    Yes   |
|  6   |    Yes   |
|  7   |    Yes   |
—————————————————————————————————————————————————————————————————————————————————————————————————*/

namespace Develop04
{
    public class Listing : Activity
    {
        //  *********************
        //      * SUMMARY*
        //
        //      ATTRIBUTES:   1
        //      INSTANCES:    0
        //      CONSTRUCTORS: 1
        //      METHODS:      1
        //  *********************


        // ATTRIBUTES...............................................................................(1)
        // A1. _promptsListing

        // A1.
        private List<string> _promptsListing;

        // INSTANCES................................................................................(0)

        // CONSTRUCTORS.............................................................................(1)
        // C1. Listing

        // C1.
        public Listing(string name, string description, string durationRequestMsg)
            : base(name, description, durationRequestMsg) // Pass Name and Description to base class for initialization
        {
            _promptsListing = new List<string> // 10 prompts
            {
                "What is something you accomplished recently that you're proud of?",
                "When have you felt truly at peace this week?",
                "Who in your life makes you feel supported and why?",
                "What blessings have you noticed in your life lately?",
                "When have you acted with kindness even when it was difficult?",
                "What talents or gifts do you feel grateful for?",
                "Who have you seen make a positive impact recently?",
                "When was a time you felt guided in making a good decision?",
                "What's a moment from today that made you smile?",
                "How have you seen God's hand in your life this past week?",
            };
        }

        // METHODS..................................................................................(1)
        // M1. RunListing

        // M1.
        /* ROADMAP
        //  | Step |      Summary                        | Status |
        //  |......|.....................................|........|
        //  |   1  | Prologue/Greeting with description  | Done   |
        //  |   2  | Prompt for duration                 | Done   |
        //  |   3  | Select random prompt                | Done   |
        //  |   4  | Countdown before listing            | Done   |
        //  |   5  | Prompt to keep listing              | Done   |
        //  |   6  | Count items listed                  | Done   |
        //  |   7  | Display number of items listed      | Done   |
        //  |   8  | Epilogue/Ending message             | Done   | */
        public void RunListing()
        {
            // Steps 1 and 2: Prologue/Greeting with description and prompt for duration

            // Introduce activity and set duration
            SetDuration(DisplayPrologue()); // Activity duration = user input (seconds)

            // LISTING functionality:

            // Step 3: Select random prompt

            // Random integers (prompts and questions)
            int randNumPrompt = new Random().Next(0, _promptsListing.Count); // Random prompt index

            // Output intro:
            Console.Clear();
            Console.WriteLine(
                "Instructions:\n   > Read the prompt as the countdown begins. Then, list as many things as you can. Press enter after each item.\n"
            );
            PressEnterToContinue();
            Console.Clear();
            spinner.Spin(1); // 1 second
            Console.WriteLine($"Prompt:\n   > {_promptsListing[randNumPrompt]}\n");
            Console.WriteLine("Activity will begin in 10 seconds...");

            // Step 4: Countdown before listing

            spinner.Spin(10); // 10 second
            Console.Clear();
            Console.WriteLine($"Prompt:\n   > {_promptsListing[randNumPrompt]}\n");

            // Step 5: Begin listing

            spinner.Spin(1); // 1 second
            Console.WriteLine("\nBegin listing...\n");

            DateTime start_time = DateTime.Now; // Start time for activity duration
            DateTime end_time = start_time.AddSeconds(_duration); // End time based on duration

            int itemCount = 0; // Counter for items listed
            string userInput;
            do
            {
                // Step 6: Count items listed

                itemCount++; // Increment item count
                Console.Write($"  {itemCount}. ");
                userInput = Console.ReadLine().Trim(); // Read user input
            } while (DateTime.Now < end_time); // Loop until the duration is reached

            // Step 7: Display number of items listed

            Console.WriteLine($"\nYou listed {itemCount} items!\n");
            PressEnterToContinue();

            // Step 8: Epilogue/Ending message

            // End activity and display summary
            DisplayEpilogue();
        }
    }
}
