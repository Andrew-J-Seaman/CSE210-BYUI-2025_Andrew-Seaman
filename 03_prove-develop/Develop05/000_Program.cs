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
            string goalsFilePath = "goals.csv";
            string pointsFilePath = "points.txt";
            List<Goal> goals;
            int totalPoints = 0;


            // Menu options......................
            List<string> _menuOptions01 = new List<string> { "Create New Goal", "List Goals", "Save Goals", "Record Event", "Quit" }; // Tier 1: Main Menu

            List<string> _menuOptions02 = new List<string> { "Simple", "Eternal", "Checklist", "Back" }; // Tier 2: Create New Goal Menu

            // ————————————————————————————————————————————————————————————————————————————————————
            // READ IN DATA FILES
            // ————————————————————————————————————————————————————————————————————————————————————

            // Quietly check for goals.csv file and read in data
            goals = LoadGoals(goalsFilePath, true); // Disable error message

            // Quietly check for points.txt file and read in data
            totalPoints = LoadPoints(pointsFilePath);


            // ————————————————————————————————————————————————————————————————————————————————————
            // MENU SYSTEM
            // ————————————————————————————————————————————————————————————————————————————————————

            // Menu object instances            
            Menu mainMenu = new Menu("Main Menu:", _menuOptions01);
            Menu createNewGoalMenu = new Menu("Create a New Goal: ", _menuOptions02);

            // Main menu
            bool running = true;
            while (running) // Outer loop
            {
                Clear(); // ! NOTICE !
                // Tier 1__________________________________________________________________________
                switch (mainMenu.GetValidatedMenuSelection(totalPoints)) // Menu is called to run here 
                {
                    case 1: // > (1) "Create New Goal" ____________________________________________
                        bool inCreateNewGoalMenu = true;
                        while (inCreateNewGoalMenu)
                        {
                            Clear(); // ! NOTICE !

                            // Tier 2 (Create New Goal) ___________________________________________
                            switch (createNewGoalMenu.GetValidatedMenuSelection(totalPoints))
                            {
                                case 1: // * Simple ...............................................
                                    Simple sGoal = GoalBuilder.CreateSimpleGoalFromUser();
                                    goals.Add(sGoal);
                                    break;

                                case 2: // * Eternal ..............................................
                                    Eternal eGoal = GoalBuilder.CreateEternalGoalFromUser();
                                    goals.Add(eGoal);
                                    break;

                                case 3: // * Checklist ............................................
                                    Checklist cGoal = GoalBuilder.CreateChecklistGoalFromUser();
                                    goals.Add(cGoal);
                                    break;

                                case 4: // * Return  ..............................................
                                    inCreateNewGoalMenu = false; // Return to Main Menu
                                    break;
                            }
                        }
                        break;

                    case 2: // > "List Goals" _____________________________________________________
                        Clear(); // ! NOTICE !

                        ListGoals(goals);
                        PressEnter();
                        break;

                    case 3: // > "Save Goals" _____________________________________________________
                        Clear(); // ! NOTICE !
                        // Write POINTS to 'points.txt'
                        File.WriteAllText(pointsFilePath, totalPoints.ToString()); // ! WRITING TO A FILE !


                        // Create an empty list to store all formatted lines.
                        List<string> lines = [];

                        // Check if there are new entries to save.
                        if (goals.Count() > 0)
                        {
                            // Format each Goal object as a line of text separated by "|" for file output.
                            foreach (Goal goalTemp in goals)
                            {
                                string line = goalTemp.FormatGoalOutput();
                                lines.Add(line);
                            }

                            // Write all GOALS to 'goals.csv'
                            File.WriteAllLines(goalsFilePath, lines); // ! WRITING TO A FILE !

                            // Display success message
                            Console.WriteLine("Saving goals...");
                            Thread.Sleep(2000);
                            Clear(); // ! NOTICE !
                            Console.WriteLine($"{goals.Count()} goals saved successfully!");
                            Thread.Sleep(1000);
                        }
                        else // Goals list was empty
                        {
                            Console.WriteLine("No goals to save");
                        }
                        break;

                    case 4: // > "Record Event" ___________________________________________________
                        Clear(); // ! NOTICE !

                        ListGoals(goals);
                        Console.Write("\n> Enter a number of goal for which you have completed an event: ");
                        int input = int.Parse(Console.ReadLine()); // Selected goal
                        Goal goal = goals[input - 1]; // Index offset by one.

                        // Record an event for the selcted goal
                        totalPoints += goal.RecordEvent();

                        // PressEnter();
                        break;

                    case 5: // > "Quit" ___________________________________________________________
                        Clear(); // ! NOTICE !
                        Console.WriteLine("Good job tracking your goals!\n");
                        Thread.Sleep(500);
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

        private static List<Goal> LoadGoals(string goalsFilePath, bool DisableErrorMessage = false)
        {
            if (File.Exists(goalsFilePath))
            {
                // Goals list
                List<Goal> goals = new List<Goal>();

                // Read existing goals
                string[] existingGoals = File.ReadAllLines(goalsFilePath);

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
                            // Format Goal Output ...........................................
                            //   0: _title
                            //   1: _description
                            //   2: _type
                            //   3: _checksActual
                            //   4: _checksTarget
                            //   5: _rewardCheck
                            //   6: _rewardTarget
                            //   7: _status

                            // * Simple ...............................................
                            case "Simple":
                                Simple sGoal = new Simple(      // Simple (C2)
                                    goalParts[0],                   // 0: _title            string
                                    goalParts[1],                   // 1: _description      string
                                    int.Parse(goalParts[6]),        // 6: _rewardTarget     int
                                    bool.Parse(goalParts[7]));                  // 7: _status           bool
                                goals.Add(sGoal); // Add to list
                                break;

                            // * Eternal ..............................................
                            case "Eternal":
                                Eternal eGoal = new Eternal(    // Eternal (C2)
                                    goalParts[0],                   // 0: _title            string
                                    goalParts[1],                   // 1: _description      string
                                    int.Parse(goalParts[3]),        // 3: _checksActual     int
                                    int.Parse(goalParts[5]));       // 5: _rewardCheck      int
                                goals.Add(eGoal); // Add to list
                                break;

                            // * Checklist ............................................
                            case "Checklist":
                                Checklist cGoal = new Checklist( // Checklist (C2)
                                    goalParts[0],                   // 0: _title            string
                                    goalParts[1],                   // 1: _description      string
                                    int.Parse(goalParts[3]),        // 3: _checksActual     int
                                    int.Parse(goalParts[4]),        // 4: _checksTarget     int
                                    int.Parse(goalParts[5]),        // 5: _rewardCheck      int
                                    int.Parse(goalParts[6]),        // 6: _rewardTarget     int
                                    bool.Parse(goalParts[7]));       // 7: _status           bool
                                goals.Add(cGoal); // Add to list
                                break;
                        }

                    }

                }
                return goals;

            }
            else
            {
                if (!DisableErrorMessage)
                {
                    Console.WriteLine("No goals file found"); //....................... UX
                    // Create file
                    File.Create(goalsFilePath);
                    Console.WriteLine("Creating a new goals file..."); //.............. UX
                    Thread.Sleep(1000);//.............................................. UX
                    Console.WriteLine("Done!");
                }

                return new List<Goal>();
            }

        }

        private static void ListGoals(List<Goal> goals)
        {
            string starbar = new string('*', 17);
            Console.WriteLine(starbar + "\n*     GOALS     *\n" + starbar + "\n");
            for (int i = 0; i < goals.Count(); i++)
            {
                Goal goal = goals[i]; // Goal object
                int oneBasedIndex = i + 1;
                goal.DisplayGoal(oneBasedIndex);
            }
        }

        private static int LoadPoints(string pointsFilePath)
        {
            if (File.Exists(pointsFilePath))
            {
                int points = 0; // Default value (prior to reading from file.)

                // Read earned points
                string[] lines = File.ReadAllLines(pointsFilePath);
                if (lines.Length > 0 && lines[0] != "")
                {
                    points = int.Parse(lines[0]);
                }
                return points;
            }
            else
            {
                return 0;
            }
        }
    }
    
}
