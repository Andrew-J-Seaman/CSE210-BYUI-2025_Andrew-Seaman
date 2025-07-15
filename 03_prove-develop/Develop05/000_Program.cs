//**************************************************
// PROJECT: Eternal Quest (Develop05)
//
// AUTHOR: Andrew Seaman
// DATE: 2025-Jul-10
//**************************************************

using System;
using System.Runtime.ExceptionServices;

namespace Develop05
{
    class Program // Class000
    {
        

        static void Main(string[] args)
        {
            // ————————————————————————————————————————————————————————————————————————————————————
            // PROGRAM : Write your code here
            // ————————————————————————————————————————————————————————————————————————————————————

            // VARIABLES
            // __________________________________
            // Local variables
            List<Goal> _goals = new List<Goal> { };
            List<Goal> _stagedGoals = new List<Goal> { };
            
            // Menu options lists (local stack variables)
            List<string> _menuOptions01 = new List<string> { "Actions", "Customization", "Quit" };
            List<string> _menuOptions02 = new List<string> { "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Return to Main Menu" };
            List<string> _menuOptions03 = new List<string> { "Simple", "Eternal", "Checklist", "Return to Actions Menu" };
            List<string> _menuOptions04 = new List<string> { "Proceed", "Save Changes" };

            // Main Menu
            bool running = true;
            while (running) // Outer loop
            {
                Menu mainMenu = new Menu("Main Menu:", _menuOptions01);
                ClearAll();
                // Tier 1__________________________________________________________________________
                switch (mainMenu.GetValidatedMenuSelection())
                {
                    case 1: // 1.1/3 "Actions"............................
                        bool inActionsMenu = true;

                        while (inActionsMenu) // Inner loop
                        {
                            Menu actionsMenu = new Menu("Actions Menu: ", _menuOptions02);
                            ClearAll();

                            // Tier 2______________________________________________________________
                            switch (actionsMenu.GetValidatedMenuSelection())
                            {
                                case 1: // 2.1/6 "Create New Goal"..........................
                                    bool inCreateNewGoalMenu = true;

                                    while (inCreateNewGoalMenu)
                                    {
                                        Menu createNewGoalMenu = new Menu("Create a New Goal: ", _menuOptions03, suffix: " Goal");
                                        ClearAll();

                                        // Tier 3__________________________________________________
                                        switch (createNewGoalMenu.GetValidatedMenuSelection())
                                        {
                                            case 1: // 3.1/4 "Simple"
                                                Simple sGoal = GoalBuilder.CreateSimpleGoalFromUser();
                                                _stagedGoals.Add(sGoal);
                                                break;

                                            case 2: // 3.2/4 "Eternal"
                                                Eternal eGoal = GoalBuilder.CreateEternalGoalFromUser();
                                                _stagedGoals.Add(eGoal);
                                                break;

                                            case 3: // 3.3/4 "Checklist":
                                                Checklist cGoal = GoalBuilder.CreateChecklistGoalFromUser();
                                                _stagedGoals.Add(cGoal);
                                                break;

                                            case 4: // 3.4/4 "Return to Actions Menu"
                                                inCreateNewGoalMenu = false; // Exit Actions menu
                                                break;
                                        }
                                    }
                                    inActionsMenu = false;
                                    break;

                                case 2: // 2.2/6 "List Goals"...............................
                                    // Add Logic: ListGoals();
                                    inActionsMenu = false;
                                    break;

                                case 3: // 2.3/6 "Save Goals"...............................
                                        // Add Logic: SaveGoals(); Full if logic: 

                                    _goals ? (_goals = _stagedGoals) : _goals.Add(_stagedGoals);
                                    inActionsMenu = false;
                                    break;

                                case 4: // 2.4/6 "Load Goals"...............................
                                    // Add Logic: LoadGoals();
                                    inActionsMenu = false;
                                    break;

                                case 5: // 2.5/6 "Record Event".............................
                                    // Add Logic: menu (_goals) > RecordEvent();
                                    inActionsMenu = false;
                                    break;

                                case 6: // 2.6/6 "Return to Main Menu"......................
                                    Console.WriteLine("Returning to Main menu");
                                    inActionsMenu = false;
                                    break;
                            }
                        }
                        break;

                    case 2: // 1.2/3 "Customization"......................

                        // Tier 2__________________________________________________________________

                        // 1. Add options list above (two options)
                        // 2. Add tier 2 switch-case 

                        break;

                    case 3: // 1.3/3 "Quit"...............................
                        // Logic: warn user if there are any unsaved goals and offer to save them before quitting.
                        // if (instance of _stagedGoals) <----------------------------------------------------------------------- RETURN TO THIS LOGIC ISSUE.
                        int count = _stagedGoals.Count();
                        if (count > 0)
                        {
                            Menu quitMenu = new Menu($"You have {count} staged ready to be saved: ", _menuOptions04);
                            ClearAll();
                            switch (quitMenu.GetValidatedMenuSelection())
                            {
                                case 1: // Proceed (lose unsaved work)
                                    break;

                                case 2: // Save Changes (save unsaved work)
                                    // Add Logic: SaveGoals();

                                    break;
                            }

                        }
                        ClearAll();
                        Console.WriteLine("Thanks for making goals!");
                        break;
                } // End switch-case: Level 1
            } // End while loop: Level 1
        }

        private static void ClearAll()
        {
            Console.Clear();
        }
        
    }
}
