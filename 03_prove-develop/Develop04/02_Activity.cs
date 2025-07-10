//**********************************
// PROJECT: Mindfullness (Develop04)
//**********************************

namespace Develop04
{
    public class Activity
    {
        //  *********************
        //      * SUMMARY*
        //
        //      ATTRIBUTES:   4
        //      INSTANCES:    1
        //      CONSTRUCTORS: 1
        //      METHODS:      5
        //  *********************


        // ATTRIBUTES...............................................................................(4)
        // A1. _duration
        // A2. _name
        // A3. _description
        // A4. _durationRequestMsg

        // A1.
        protected int _duration;

        // A2.
        private string _name;

        // A3.
        private string _description;

        // A4.
        private string _durationRequestMsg;

        // INSTANCES................................................................................(1)
        // I1. spinner

        // I1.
        protected Spinner spinner = new Spinner();

        // CONSTRUCTORS.............................................................................(1)
        // C1. Activity

        // C1.
        public Activity(string name, string description, string durationRequestMsg)
        {
            // PURPOSE: Get `name`, `description`, and `durationRequestMsg` from Program class to initialize the activity object.
            _name = name;
            _description = description;
            _durationRequestMsg = durationRequestMsg;
        }

        // METHODS..................................................................................(5)
        // M1. DisplayPrologue
        // M2. DisplayEpilogue
        // M3. SetDuration
        // M4. GenerateRndmNum
        // M5. PressEnterToContinue

        // M1.
        public int DisplayPrologue()
        {
            // PURPOSE: Each activity should start with a common starting message that provides the name of the activity, a description, and asks for and sets the duration of the activity in seconds. Then, it should tell the user to prepare to begin and pause for several seconds.

            // Name: So the user knows which activity they're doing
            Console.Clear();
            Console.Write("The ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(_name); // This part will be blue
            Console.ResetColor();
            Console.WriteLine(" activity will begin shortly.");
            spinner.Spin(2); // 2 second

            // Description: So the user understands the activity before they begin
            Console.Clear();
            Thread.Sleep(300);
            string star_bar = new string('*', _name.Length + 4); // Used for title bar display format
            Console.Write($"{star_bar}\n> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{_name.ToUpper()}");
            Console.ResetColor();
            Console.Write(" <\n");
            Console.WriteLine($"{star_bar}\n");
            Thread.Sleep(300);
            Console.WriteLine($"Description:\n   > {_description}\n"); // Display activity description
            Thread.Sleep(300);
            PressEnterToContinue();
            spinner.Spin(1); // 1 second

            // Request Duration: so the user can set the activity duration
            int durationValue;
            bool isInt = false;

            do
            {
                Console.Write($"{_durationRequestMsg} ");

                if (int.TryParse(Console.ReadLine().Trim(), out durationValue))
                {
                    isInt = true; // Exit loop
                }
                else
                {
                    Console.WriteLine("Invalid entry. A number is required.");
                }
            } while (!isInt);

            return durationValue; // This output serves as the input for the 'SetDuration' method
        }

        // M2.
        public void DisplayEpilogue()
        {
            // PURPOSE: Each activity should end with a common ending message that tells the user they have done a good job, and pause and then tell them the activity they have completed and the length of time and then pause for several seconds before finishing.

            // Clear the console
            Console.Clear();

            // Tell user good job
            Console.WriteLine($"Good job!");
            spinner.Spin(3); // 3 seconds
            Console.WriteLine($"\nYou've completed a {_name} activity which lasted {_duration} seconds.");
            spinner.Spin(3); // 3 seconds
        }

        // M3.
        public void SetDuration(int duration)
        {
            // PURPOSE: set duration from user input
            _duration = duration;
        }

        // M4.
        public void GenerateRndmNum()
        {
            // PURPOSE: generate a random number for prompt and/or question selection.

            Random random = new Random();
            int randomNumber = random.Next();
        }

        // M5.
        public void PressEnterToContinue()
        {
            string pressEnterTxt = "(Press |ENTER| to continue)";
            string[] items = pressEnterTxt.Split("|");
            int fullTextLength = 0;

            foreach (string item in items)
            {
                if (item != items[1])
                {
                    Console.Write(item);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(item);
                    Console.ResetColor();
                }

                fullTextLength += item.Length;
            }
            Console.ReadLine();

            // Clear the line by resetting cursor position and overwriting with spaces
            Console.SetCursorPosition(0, Console.CursorTop - 1); // Move cursor to the line where `press_enter` was written
            Console.Write(new string(' ', fullTextLength)); // Overwrite with spaces
            Console.SetCursorPosition(0, Console.CursorTop); // Reset cursor to the beginning of the current line
        }
    }
}
