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
            // LOAD GOALS AUTOMATICALLY
            // ————————————————————————————————————————————————————————————————————————————————————

            // Quietly check for goals.csv file and read in data
            _goals = LoadGoals(_goalsFilePath, true); // Disable error message

            // ————————————————————————————————————————————————————————————————————————————————————
            // MENU SYSTEM
            // ————————————————————————————————————————————————————————————————————————————————————

            // Main Menu
            bool running = true;
            while (running) // Outer loop
            {
                Menu mainMenu = new Menu("Main Menu:", _menuOptions01);
                Clear();
                // Tier 1__________________________________________________________________________
                switch (mainMenu.GetValidatedMenuSelection())
                {
                    case 1: // * "Create New Goal"..........................
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

                    case 2: // * "List Goals"...............................
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

                    case 3: // * "Save Goals"...............................
                        Clear();

                        // Format Goals for output (list of strings)

                        // Create an empty list to store all formatted lines.
                        List<string> lines = [];

                        // Check if there are new entries to save.
                        if (_goals.Count() > 0)
                        {
                            // Read existing goals
                            // LoadGoals(_goalsFilePath, false); // ? Still necessary?

                            // Loop through each new goal and format it as a line of text separated by "|".
                            foreach (Goal goal in _goals)
                            {
                                string line = goal.FormatGoalOutput();
                                lines.Add(line);
                            }

                            // // <!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!>
                            // // ! TEMPORARY DEBUGGING "PRINT STATEMENT"
                            // // Verify each line from file is read in properly and each new goal object's data is formatted correctly for writing to the file ('goals.csv').
                            // int i = 1;
                            // foreach (string line in lines)
                            // {
                            //     string indexedLine = $"{i}. {line}";
                            //     Wr(indexedLine);
                            //     Wr("\n");
                            //     i++; // Increment index (1-based)
                            // }
                            // <!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!><!>

                            // (SAVE) Overwrite the file ('goals.csv')
                            File.WriteAllLines(_goalsFilePath, lines);

                            // Display success message
                            Console.WriteLine("Saving goals...");
                            Thread.Sleep(2000);
                            Clear();
                            Console.WriteLine($"{_goals.Count()} goals saved successfully!");
                            PressEnter();
                        }
                        else
                        {
                            Console.WriteLine("No goals to save");
                        }

                        break;

                    case 4: // * "Load Goals".............................
                        // Add Logic: LoadGoals();
                        break;

                    case 5: // * "Record Event"...........................
                        // Add Logic: menu (_goals) > RecordEvent();
                        break;

                    case 6: // * "Quit"...................................
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
                // Goals list
                List<Goal> _goals = new List<Goal>();

                // Read existing goals
                string[] existingGoals = File.ReadAllLines(_goalsFilePath);

                // Validate the file is not empty
                if (existingGoals.Length > 0 && existingGoals[0] != "")
                {
                    foreach (string goal in existingGoals)
                    {
                        // Initialize goal object
                        string[] goalParts = goal.Split("|"); // Parse formatted goal data string
                        string goalType = goalParts[2]; // Access goal type. Always index 2 or third list item.
                        switch (goalType)
                        {
                            // string formatted_goal = 
                            //   0: _title
                            //   1: _description
                            //   2: _type
                            //   3: _checksActual
                            //   4: _checksTarget
                            //   5: _rewardCheck
                            //   6: _rewardTarget
                            //   7: _rewardBonus
                            //   8: _status

                            case "Simple":
                                //   0: _title              string
                                //   1: _description        string
                                //   6: _rewardTarget      int
                                Simple sGoal = new Simple(
                                    goalParts[0],
                                    goalParts[1],
                                    int.Parse(goalParts[6]));
                                // ! remove: Simple sGoal = GoalBuilder.CreateSimpleGoalFromUser();

                                _goals.Add(sGoal);
                                break;

                            case "Eternal":
                                //   0: _title              string
                                //   1: _description        string
                                //   4: _rewardCheck        int
                                Eternal eGoal = new Eternal(
                                    goalParts[0],
                                    goalParts[1],
                                    int.Parse(goalParts[5]));

                                _goals.Add(eGoal);
                                // ! remove: Eternal eGoal = GoalBuilder.CreateEternalGoalFromUser();
                                break;

                            case "Checklist":
                                //   0: _title              string
                                //   1: _description        string
                                //   4: _checksTarget       int
                                //   5: _rewardCheck        int
                                //   6: _rewardTarget       int
                            
                                // public Checklist( string title, string description, int checksTarget, int rewardCheck, int rewardTarget )
                                Checklist cGoal = new Checklist(
                                    goalParts[0],
                                    goalParts[1],
                                    int.Parse(goalParts[4]),
                                    int.Parse(goalParts[5]),
                                    int.Parse(goalParts[6]));
                                // ! remove: Checklist cGoal = GoalBuilder.CreateChecklistGoalFromUser();
                                
                                _goals.Add(cGoal);
                                break;
                        }

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
