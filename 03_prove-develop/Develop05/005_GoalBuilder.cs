using System;
using System.Collections.Generic;
using System.Linq;

namespace Develop05
{
    public static class GoalBuilder
    {
        public static List<string> _goalTypes = new List<string> { "Simple", "Eternal", "Checklist" };
        public static string _replacementWord;

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS : Create
        // ————————————————————————————————————————————————————————————————————————————————————————

        // MC1...................................
        public static Simple CreateSimpleGoalFromUser()
        {
            // Goal Type: ********* SIMPLE *********
            string goalType = _goalTypes[0];

            // Prompt for attributes
            string title = AskForTitle();
            // DateTime targetDeadline = AskForTargetDeadline(goalType);
            int rewardTarget = AskForRewardForTarget(goalType);

            // Instantiate new goal object
            return new Simple(
                title,
                // targetDeadline,
                rewardTarget); // 3 parameters
        }

        // MC2...................................
        public static Eternal CreateEternalGoalFromUser()
        {
            // Goal Type: ********* ETERNAL *********
            string goalType = _goalTypes[1];

            // Prompt for attributes
            string title = AskForTitle();
            // (string checksFrequency, int frequencyMultiplier) = AskForFrequency();
            // int checksTarget = AskForChecksTarget(goalType);
            // DateTime targetDeadline = AskForTargetDeadline(goalType, checksTarget, frequencyMultiplier);
            int rewardCheck = AskForRewardPerCheck();
            int rewardTarget = AskForRewardForTarget(goalType);

            // Instantiate new goal object
            return new Eternal(
                title,
                // checksFrequency,
                // checksTarget,
                // targetDeadline,
                rewardCheck,
                rewardTarget); // 6 parameters
        }

        // MC3...................................
        public static Checklist CreateChecklistGoalFromUser()
        {
            // Goal Type: ********* CHECKLIST *********
            string goalType = _goalTypes[2];

            // Prompt for attributes
            string title = AskForTitle();
            // (string checksFrequency, int frequencyMultiplier) = AskForFrequency();
            int checksTarget = AskForChecksTarget(goalType);
            // DateTime targetDeadline = AskForTargetDeadline(goalType, checksTarget, frequencyMultiplier);
            int rewardCheck = AskForRewardPerCheck();
            int rewardTarget = AskForRewardForTarget(goalType);

            // Instantiate new goal object
            return new Checklist(
                title, 
                // checksFrequency, 
                checksTarget, 
                // targetDeadline, 
                rewardCheck, 
                rewardTarget); // 6 parameters
        }


        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS : Prompt
        // ————————————————————————————————————————————————————————————————————————————————————————

        // MP1...................................
        private static string AskForTitle()
        {
            // Prompt
            Console.Write("Enter goal title: ");
            // Read input
            return Console.ReadLine();
        }
        // MP2...................................
        private static (string, int) AskForFrequency()
        {
            // Dict: {frquency, multiplier}
            Dictionary<string, int> frequencies = new Dictionary<string, int>
            {
                { "Daily", 1 }, { "Weekly", 7 }, { "Monthly", 30 }, { "Yearly", 365 }
            };

            List<string> keys = frequencies.Keys.ToList(); // Dict keys as list for iteration in sub-menu logic.
            Menu frequenciesMenu = new Menu("Goal Frequencies:", keys, "> Choose goal frequency (number):");
            int selectionIndex = frequenciesMenu.GetValidatedMenuSelection(); // Run menu

            string chosenKey = keys[selectionIndex - 1];
            int chosenValue = frequencies[chosenKey];
            return (chosenKey, chosenValue);
        }

        // MP3...................................
        private static int AskForChecksTarget(string goalType)
        {
            // Dynamic prompt based on goal type
            _replacementWord = (goalType == _goalTypes[1] || goalType == _goalTypes[2]) ? "streak" : "checklist";
            // Prompt
            Console.Write($"Enter {_replacementWord} target: ");
            // Read input
            return int.Parse(Console.ReadLine());
        }

        // MP4...................................
        private static DateTime AskForTargetDeadline(string goalType, int checksTarget = 1, int frequencyMultiplier = 1)
        {
            // Dynamic prompt based on goal type
            int daysToAdd = 0;

            if (goalType == _goalTypes[1] || goalType == _goalTypes[2])
            {
                // Calculate using passed in parameters
                daysToAdd = checksTarget * frequencyMultiplier;
            }
            else if (goalType == _goalTypes[0])
            {
                // Prompt user
                Console.Write("How many days out from today do you wish to set as the target deadline? ");
                daysToAdd = int.Parse(Console.ReadLine());
            }

            // Generate target deadline
            return DateTime.Now.AddDays(daysToAdd); // Add days

        }

        // MP5...................................
        private static int AskForRewardPerCheck()
        {
            // Prompt
            Console.Write("Enter reward per check: ");
            // Read input
            return int.Parse(Console.ReadLine());
        }

        // MP6...................................
        private static int AskForRewardForTarget(string goalType)
        {
            // Replacement words
            List<string> replacementWords = new List<string> { "completion", "streak", "check" };

            int index = _goalTypes.IndexOf(goalType);

            _replacementWord = replacementWords[index];

            // Dynamic prompt construction
            Console.Write($"Enter reward for reaching the {_replacementWord} target: ");
            // Read input
            return int.Parse(Console.ReadLine());
        }
    }
}