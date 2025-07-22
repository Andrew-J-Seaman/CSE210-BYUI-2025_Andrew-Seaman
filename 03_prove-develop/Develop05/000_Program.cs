//**************************************************
// PROJECT: Eternal Quest (Develop05)
//
// AUTHOR: Andrew Seaman
// DATE: 2025-Jul-10
//**************************************************

using System;
using System.Runtime.ExceptionServices;
using System.IO;

namespace Develop05
{
    class Program // Class000
    {


        static void Main(string[] args)
        {
            // ————————————————————————————————————————————————————————————————————————————————————
            // VARIABLES
            // ————————————————————————————————————————————————————————————————————————————————————

            // Local...................
            string _goalsFilePath = "goals.csv";
            List<Goal> _goals;


            // Menu options......................
            List<string> _menuOptions01 = new List<string> { "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit" }; // Main Menu: 2 Tier model

            List<string> _menuOptions02 = new List<string> { "Simple", "Eternal", "Checklist", "Return to Main Menu" }; // Create New Goal Menu

            // ————————————————————————————————————————————————————————————————————————————————————
            // MENU
            // ————————————————————————————————————————————————————————————————————————————————————

            // Quietly check for goals.csv file and read in data
            _goals = LoadGoals(_goalsFilePath, true); // Disable error message

            // Main Menu
            bool running = true;
            while (running) // Outer loop
            {
                Menu mainMenu = new Menu("Main Menu:", _menuOptions01);
                Clear();
                // Tier 1__________________________________________________________________________
                switch (mainMenu.GetValidatedMenuSelection())
                {
                    case 1: // "Create New Goal"..........................
                        bool inCreateNewGoalMenu = true;
                        while (inCreateNewGoalMenu)
                        {
                            Menu createNewGoalMenu = new Menu("Create a New Goal: ", _menuOptions02);
                            Clear();

                            // Tier 2______________________________________________________________
                            switch (createNewGoalMenu.GetValidatedMenuSelection())
                            {
                                case 1: // 3.1/4 "Simple"
                                    Simple sGoal = GoalBuilder.CreateSimpleGoalFromUser();
                                    _goals.Add(sGoal);
                                    break;

                                case 2: // 3.2/4 "Eternal"
                                    Eternal eGoal = GoalBuilder.CreateEternalGoalFromUser();
                                    _goals.Add(eGoal);
                                    break;

                                case 3: // 3.3/4 "Checklist":
                                    Checklist cGoal = GoalBuilder.CreateChecklistGoalFromUser();
                                    _goals.Add(cGoal);
                                    break;

                                case 4: // 3.4/4 "Return to Actions Menu"
                                    inCreateNewGoalMenu = false; // Exit Actions menu
                                    break;
                            }
                        }
                        break;

                    case 2: // "List Goals"...............................
                        Clear();
                        Console.WriteLine("——— GOALS ———\n");
                        for (int i = 0; i < _goals.Count(); i++)
                        {
                            Goal goal = _goals[i]; // Goal object
                            int oneBasedIndex = i + 1;
                            goal.DisplayGoal(oneBasedIndex);
                        }
                        PressEnter();
                        break;

                    case 3: // "Save Goals"...............................
                        Clear();

                        // Format Goals for output (list of strings)

                        // Create an empty list to store all formatted lines.
                        List<string> lines = [];

                        // Check if there are new entries to save.
                        if (_goals.Count() > 0)
                        {
                            // Read existing goals
                            LoadGoals(_goalsFilePath,false);

                            // Loop through each new goal and format it as a line of text separated by "|".
                            foreach (Goal goal in _goals)
                            {
                                string line = goal.FormatGoalOutput();
                                lines.Add(line);
                            }

                            // <!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!>
                            // TEMPORARY DEBUGGING "PRINT STATEMENT". Verify each line from file is read in properly and each new goal object's data is formatted correctly for writing to the file ('goals.csv').
                            int i = 1;
                            foreach (string line in lines)
                            {
                                string indexedLine = $"{i}. {line}";
                                Wr(indexedLine);
                                Wr("\n");
                                i++; // Increment index (1-based)
                            }

                            PressEnter();
                            // <!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!>

                            // (SAVE) Overwrite the file
                            File.WriteAllLines(_goalsFilePath, lines);

                            // Reinitialize `_goals` only after successful write (i.e. wipe the list).
                            _goals = new List<Goal>();

                            Console.WriteLine("Saving goals...");

                            Console.WriteLine("Goals saved successfully!");
                        }
                        else
                        {
                            Console.WriteLine("No goals to save");
                        }

                        break;

                    case 4: // "Load Goals"...............................
                        // Add Logic: LoadGoals();
                        break;

                    case 5: // "Record Event".............................
                        // Add Logic: menu (_goals) > RecordEvent();
                        break;

                    case 6: // "Quit"...............................
                        Clear();
                        Console.WriteLine("Good job tracking your goals!");
                        running = false;
                        break;
                }
            }
        }

        // ————————————————————————————————————————————————————————————————————————————————————
        // Methods
        // ————————————————————————————————————————————————————————————————————————————————————

        // M1....................................
        public static void Clear()
        {
            Console.Clear();
        }

        private static void Wr(string text, string color = "")
        {
            if (color == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(text);
                Console.ResetColor();
            }
            else if (color == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(text);
                Console.ResetColor();
            }
            else
            {
                Console.Write(text);
            }
        }

        private static void PressEnter()
        {
            Wr("\n(Press [ ");
            Wr("ENTER", "green");
            Wr(" ] to continue)");
            Console.ReadLine();
        }

        private static List<Goal> LoadGoals(string _goalsFilePath, bool DisableErrorMessage = false)
        {
            if (File.Exists(_goalsFilePath))
            {
                // Read existing goals
                string[] existingGoals = File.ReadAllLines(_goalsFilePath);
                List<Goal> _goals = new List<Goal>();
                foreach (string goal in existingGoals)
                {
                    // Initialize goal object
                    string[] goalParts = goal.Split("|"); // Parse formatted goal data string
                    string goalType = goalParts[goalParts.Count() - 1]; // Access goal type
                    switch (goalType)
                    {
                        case "Simple":
                            Simple sGoal = GoalBuilder.CreateSimpleGoalFromUser();
                            _goals.Add(sGoal);
                            break;

                        case "Eternal":
                            Eternal eGoal = GoalBuilder.CreateEternalGoalFromUser();
                            _goals.Add(eGoal);
                            break;

                        case "Checklist":
                            Checklist cGoal = GoalBuilder.CreateChecklistGoalFromUser();
                            _goals.Add(cGoal);
                            break;
                    }

                }

                return _goals;
            }
            else
            {
                if (!DisableErrorMessage)
                {
                    Console.WriteLine("No goals file found");
                }
                return new List<Goal>();
            }

        }
        
    }
}
