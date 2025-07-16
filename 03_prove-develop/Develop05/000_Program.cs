//**************************************************
// PROJECT: Eternal Quest (Develop05)
//
// AUTHOR: Andrew Seaman
// DATE: 2025-Jul-10
//**************************************************

using System;
using System.Runtime.ExceptionServices;

using System.Text.Json;
using System.Text.Json.Serialization;
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
            string filePath = "goals.csv";
            List<Goal> _goals = new List<Goal> { };
            // List<Goal> _stagedGoals = new List<Goal> { };


            // Menu options......................

            // List<string> _menuOptions01 = new List<string> { "Actions", "Customization", "Quit" }; // Main Menu (Tall 3 Tier model)

            // List<string> _menuOptions01 = new List<string> { "Actions", "Quit" }; // Main Menu (Short 3 Tier model)

            List<string> _menuOptions01 = new List<string> { "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit" }; // Main Menu: 2 Tier model

            List<string> _menuOptions02 = new List<string> { "Simple", "Eternal", "Checklist", "Return to Main Menu" }; // Create New Goal Menu

            // ————————————————————————————————————————————————————————————————————————————————————
            // MENU
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
                            int oneBasedIndex = i + 1;
                            Goal goal = _goals[i]; // Goal object
                            goal.DisplayGoal(oneBasedIndex);
                        }
                        Console.Write("\nPress (ENTER) to continue.");
                        Console.ReadLine();
                        break;

                    case 3: // "Save Goals"...............................
                        Clear();
                        if (_goals.Count() <= 0)
                        {
                            Console.WriteLine("No goals to save");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Saving goals...");

                            // Format Goals for output (list of strings)
                            List<string> lines = new List<string> { }; // List<string> lines = new List<string> { };
                            foreach (Goal goal in _goals)
                            {
                                string line = goal.FormatGoalOutput();
                                lines.Add(line);
                            }

                            // Write Goals to CSV file
                            File.WriteAllLines(filePath, lines);
                            Console.WriteLine("Goals saved successfully!");
                            //_goals.Clear(); // Empty out the list


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
        private static void Clear()
        {
            Console.Clear();
        }
        
    }
}
