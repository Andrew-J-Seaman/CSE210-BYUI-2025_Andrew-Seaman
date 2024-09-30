using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // Project greeting & instructions
        Console.WriteLine(">Hello, welcome to Prep3 World!");
        Console.WriteLine(">You will guess the result of a randomly rolled dice from 1-100.'");

        string response = "y";
        while (response == "y")
        {
            // Start game message
            Console.WriteLine(">The dice has been rolled. Good luck!");

            // Generate random numbers
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100+1);

            int rounds = 0;
            bool check = false;
            int guess = -1;
            do
            {
                // Guess made
                rounds++;

                // Ask user for number
                Console.Write(">What is the magic number (1-100)? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);

                // Check answer
                if (number == guess)
                {
                    Console.WriteLine(">You guessed it! ");
                    check = true;
                }
                else if (number > guess)
                {
                    Console.WriteLine(">Higher! ");
                    check = false;
                }
                else if (number < guess)
                {
                    Console.WriteLine(">Lower! ");
                    check = false;
                }
                else
                {
                    Console.WriteLine(">Invalid guess.");
                    check = false;
                }
            } while (check == false);


            Console.Write(">Roll the dice again (y/n)? ");
            response = Console.ReadLine();

            bool valid = false;
            do
            {
                if (response != "y" && response != "n")
                {
                    Console.WriteLine($">Invalid option ('{response}'). Please enter 'y' or 'n'.");
                    Console.Write(">Roll the dice again (y/n)? ");
                    response = Console.ReadLine();  // Ask again for a valid response
                }
                else
                {
                    valid = true;  // Valid input found
                    if (response == "n")
                    {
                        string guessPlural = "guesses";
                        if (rounds == 1)
                        {
                            guessPlural = "guess";
                        }

                        Console.WriteLine($">Quitting game session... You made [{rounds}] {guessPlural}. Thank you for playing.");
                    }
                }
            } while (!valid);  // Repeat until valid input is received
        }
    }
}

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