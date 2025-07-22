//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: GoalBuilder
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .........  3
        METHODS:
            Create .........  3
            Prompt ........   5
——————————————————————————————————*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Develop05
{
    public static class GoalBuilder
    {
        // A1...................................
        static string PFX = "  > ";
        // A2...................................
        static string _goalType;
        // A3...................................
        static List<string> _goalTypes = new List<string> { "Simple", "Eternal", "Checklist" };

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS : Create
        // ————————————————————————————————————————————————————————————————————————————————————————

        // <u> Section Description: Create (derived) Goal objects.

        // MC1...................................
        // *************************** SIMPLE ***************************
        public static Simple CreateSimpleGoalFromUser()
        {
            _goalType = _goalTypes[0];

            // Prompt for attributes: keywords
            string[] keywords = ["title", "description", "rewardTarget"];
            Dictionary<string, object> inputs = SuperPrompt(keywords);

            SuccessMessage();

            // Instantiate new goal object
            return new Simple((string)inputs["title"], (string)inputs["description"], (int)inputs["rewardTarget"]);
        }

        // MC2...................................
        // *************************** ETERNAL ***************************
        public static Eternal CreateEternalGoalFromUser()
        {

            _goalType = _goalTypes[1];

            // // Prompt for attributes
            // string title, description = AskForTitleAndDescription();
            // int rewardCheck = AskForRewardPerCheck();
            // int rewardTarget = AskForRewardForTarget(goalType);

            // // Instantiate new goal object
            // return new Eternal(title, description, rewardCheck);

            // Prompt for attributes: keywords
            string[] keywords = ["title", "description", "rewardCheck"];
            Dictionary<string, object> inputs = SuperPrompt(keywords);

            SuccessMessage((string)inputs["title"]);

            // Instantiate new goal object
            return new Eternal((string)inputs["title"], (string)inputs["description"], (int)inputs["rewardCheck"]);

        }

        // MC3...................................
        // *************************** CHECKLIST ***************************
        public static Checklist CreateChecklistGoalFromUser()
        {
            _goalType = _goalTypes[2];

            // Prompt for attributes: keywords
            string[] keywords = ["title", "description", "checksTarget", "rewardCheck", "rewardTarget"];
            Dictionary<string, object> inputs = SuperPrompt(keywords);

            SuccessMessage();

            // Instantiate new goal object
            return new Checklist((string)inputs["title"], (string)inputs["description"], (int)inputs["checksTarget"], (int)inputs["rewardCheck"], (int)inputs["rewardTarget"]);

        }


        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS : Prompts
        // ————————————————————————————————————————————————————————————————————————————————————————

        // <u> Section Description: Prompts the user for (derived) Goal object attributes.

        // MP1...................................

        private static Dictionary<string, object> SuperPrompt(string[] keywords)
        {
            // Dictionary to map keywords to prompt specific text
            Dictionary<string, string> prompts = new Dictionary<string, string>
            {
                {"title", "title"},
                {"description", "description"},
                {"checksTarget", "target number of checks"},
                {"rewardCheck", "reward point value per check"},
                {"rewardTarget", "reward point value"}
            };

            // Dictionary to map keywords to return type for parsing instructions and validation
            Dictionary<string, string> returnTypes = new Dictionary<string, string>
            {
                {"title", "string"},
                {"description", "string"},
                {"checksTarget", "int"},
                {"rewardCheck", "int"},
                {"rewardTarget", "int"}
            };

            Console.Clear(); // ! NOTICE !
            Console.WriteLine($"Create a new {_goalType} goal:\n");

            Dictionary<string, object> inputs = new Dictionary<string, object>();

            foreach (string keyword in keywords)
            {
                string uniquePromptText = prompts[keyword];
                string returnType = returnTypes[keyword];

                Console.Write($"{PFX} Enter a {uniquePromptText}: ");
                object input = returnType == "int" ? int.Parse(Console.ReadLine()) : Console.ReadLine();
                inputs.Add(keyword, input);
            }
            return inputs;
        }

        public static void SuccessMessage(string title = "")
        {
            Console.Clear();
            Console.WriteLine($"\nSuccess! {_goalType} goal {title} created.\n"); // ! THIS IS THE PROBLEM. FIX "_title".
        }

        // TODO:  Test the code above to replace the code below
        // private static string SuperPrompt(string[] keywords)
        // {
        //     // Dictionary to map keywords to prompt specific text
        //     Dictionary<string, string> prompts = new Dictionary<string, string>
        //     {
        //         {"title", "title"},
        //         {"description", "description"},
        //         {"checksTarget", "target number of checks"},
        //         {"rewardCheck", "reward point value per check"},
        //         {"rewardTarget", "reward point value"}
        //     };

        //     // Dictionary to map keywords to return type for parsing instructions and validation
        //     Dictionary<string, string> returnTypes = new Dictionary<string, string>
        //     {
        //         {"title", "string"},
        //         {"description", "string"},
        //         {"checksTarget", "int"},
        //         {"rewardCheck", "int"},
        //         {"rewardTarget", "int"}
        //     };



        //     foreach (string keyword in keywords)
        //     {
        //         string uniquePromptText = prompts[keyword];
        //         string returnType = returnTypes[keyword];

        //         List<object> inputs = new List<object>();
        //         Console.Write($"{PFX} Enter a {uniquePromptText} ({_goalType} goal): ");
        //         object input = returnType == "int" ? int.Parse(Console.ReadLine()) : Console.ReadLine();
        //         inputs.Add(input);
        //     }
        //     return inputs;

        // }

        // ! DEVELOPMENT NOTE: 
        // If the 'SuperPrompter()' method works as intended then I'll be able to replace all of the other prompting methods and combine them into a single method.

        // //MP2...................................
        // private static string AskForTitleAndDescription()
        // {
        //     titlePrompt = "title";
        //     descriptionPrompt = "description";

        //     return SuperPrompt(titlePrompt) & SuperPrompt(descriptionPrompt);

        // }

        // // MP3...................................
        // private static int AskForChecksTarget()
        // {
        //     checksTargetPrompt = "target number of checks";
        //     return int.Parse(SuperPrompt(checksTargetPrompt));
        //     return int.Parse(Console.ReadLine());

        // }

        // // MP4...................................
        // private static int AskForRewardPerCheck()
        // {
        //     Console.Write($"{PFX} Enter reward point value per check ({goalType} goal): ");

        //     return int.Parse(Console.ReadLine());

        // }

        // // MP5...................................
        // private static int AskForRewardForTarget(string goalType)
        // {
        //     Console.Write($"{PFX} Enter reward point value for finally completing a goal: ");
        //     return int.Parse(Console.ReadLine());

        // }


        // ————————————————————————————————————————————————————————————————————————————————————————
        // REMOVED METHODS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // MP#...................................
        // private static DateTime AskForTargetDeadline(string goalType, int checksTarget = 1, int frequencyMultiplier = 1)
        // {
        //     // Dynamic prompt based on goal type
        //     int daysToAdd = 0;

        //     if (goalType == _goalTypes[1] || goalType == _goalTypes[2])
        //     {
        //         // Calculate using passed in parameters
        //         daysToAdd = checksTarget * frequencyMultiplier;
        //     }
        //     else if (goalType == _goalTypes[0])
        //     {
        //         // Prompt user
        //         Console.Write("How many days out from today do you wish to set as the target deadline? ");
        //         daysToAdd = int.Parse(Console.ReadLine());
        //     }

        //     // Generate target deadline
        //     return DateTime.Now.AddDays(daysToAdd); // Add days

        // }

        // MP#...................................
        // NOTE: I've pretty much removed all references to this method because I decided not to implement it. However, the logic here is impressive and usefull so I'm leaving it for the future.
        // private static (string, int) AskForFrequency()
        // {
        //     // Dict: {frquency, multiplier}
        //     Dictionary<string, int> frequencies = new Dictionary<string, int>
        //     {
        //         { "Daily", 1 }, { "Weekly", 7 }, { "Monthly", 30 }, { "Yearly", 365 }
        //     };

        //     List<string> keys = frequencies.Keys.ToList(); // Dict keys as list for iteration in sub-menu logic.
        //     Menu frequenciesMenu = new Menu("Goal Frequencies:", keys, "> Choose goal frequency (number):");
        //     int selectionIndex = frequenciesMenu.GetValidatedMenuSelection(); // Run menu

        //     string chosenKey = keys[selectionIndex - 1];
        //     int chosenValue = frequencies[chosenKey];
        //     return (chosenKey, chosenValue);
        // }

    }
    
}