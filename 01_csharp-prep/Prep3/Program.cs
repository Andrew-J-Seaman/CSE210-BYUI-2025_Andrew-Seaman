using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // ATTRIBUTES:
        int _bottomOfRange = 1; // This value may NOT be lowered but MAY be increased.
        int _topOfRange = 100; // This value MAY be increased.

        // Clear the console slate
        Console.Clear();

        // Project greeting & instructions
        Console.WriteLine("> Hello, welcome to Prep3 World! \n");
        Console.WriteLine("> You will guess the result of a randomly rolled dice (1-100).");

        // Initialize variable
        string response = "yes";

        while (response == "yes")
        {
            // Start game message
            Console.WriteLine("> The dice has been rolled. Good luck! \n");
            Console.Write("> PRESS [ENTER] ");
            Console.ReadLine();
            Console.Clear();

            // Generate random numbers
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(_bottomOfRange, _topOfRange + 1);

            // Initialize variables
            int rounds = 0;
            bool check;
            int guess;

            // PLAY THE GAME:
            do
            {
                // Guesses made
                rounds++;

                // Ask user for number
                Console.WriteLine($"> What is the magic number ({_bottomOfRange}-{_topOfRange})?");
                Console.Write("   > ");
                string input = Console.ReadLine();
                guess = int.Parse(input);

                // Move the cursor back to the same line and append feedback
                Console.SetCursorPosition(5 + input.Length, Console.CursorTop - 1);

                // Check answer and display inline result
                if (number == guess)
                {
                    Console.WriteLine($"  Correct! \n\n\n");
                    check = true;
                }
                else if (number > guess)
                {
                    Console.WriteLine($"  Higher! \n");
                    check = false;
                }
                else if (number < guess)
                {
                    Console.WriteLine($"  Lower! \n");
                    check = false;
                }
                else
                {
                    Console.WriteLine($"  Invalid guess. \n");
                    check = false;
                }
            } while (check == false);

            // CONTINUE or QUIT
            bool valid = false; // Initialize boolean

            do // Loop until valid response is provided by the user
            {
                // Continue or quit?
                Console.Write("> Roll the dice again? \n");
                Console.Write("   > ");
                response = Console.ReadLine().ToLower();

                // Invalid response
                if (response != "yes" && response != "no")
                {
                    Console.WriteLine($"> Invalid option ('{response}'). Please answer [yes/no]).");
                }
                // Valid response
                else
                {
                    valid = true;

                    // Response for quit: "no"
                    if (response == "no") // Breaks parent while loop
                    {
                        // Manage plurality of the conjugation of "guess" as needed
                        string guessPluralize = "guesses";
                        if (rounds == 1)
                        {
                            guessPluralize = "guess";
                        }

                        Console.Clear();
                        Console.WriteLine($"\n> Quitting game session.");
                        Console.WriteLine(
                            $"> You made [{rounds}] {guessPluralize}. Thank you for playing."
                        );
                    }
                }
            } while (!valid); // Loop for valid response

            // Upon exit of while loop: response is valid and is "yes".
            Console.Write("\n");

            // Response for continue: "yes"; runs parent while loop. To the top!
        } // <<< while loop >>>
    } // <<< `Main`function >>>
} // <<< `Program` class >>>




/* LOOP TYPES:

1. WHILE
string response = "yes";

while (response == "yes")
{
    Console.Write("Do you want to continue? ");
    response = Console.ReadLine();
}

2. DO-WHILE
string response;

do
{
    Console.Write("Do you want to continue? ");
    response = Console.ReadLine();
} while (response == "yes");

3. FOR
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

// OR

for (int i = 2; i <= 20; i = i + 2)
{
    Console.WriteLine(i);
}

4. FOREACH
foreach (string color in colors)
{
    Console.WriteLine(color);
}

*/

/* RANDOM NUMBERS:

Random randomGenerator = new Random();
int number = randomGenerator.Next(1, 11);

*/
