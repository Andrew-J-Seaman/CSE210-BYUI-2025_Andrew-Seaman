using System;

class Program
{
    static void Main(string[] args)
    {
        // Default greeting
        Console.Clear();
        Console.WriteLine("> Hello Prep5 World!");

        // MY FUNCTIONS:
        //Display welcome message
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // DisplayWelcome - Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("> Welcome to the Program! \n");

        // Advance
        Console.Write("   > PRESS [ENTER]");
        Console.ReadLine();
        Console.Clear();
    }
    
    // PromptUserName - Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.Write("> Enter your name: ");
        string name = Console.ReadLine();

        return name;
    }
    
    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("> Enter your favorite number (integer): ");
        int number = int.Parse(Console.ReadLine());
        
        return number;
    }

    // SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // DisplayResult - Accepts the user's name and the squared number and displays them.
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"> {name}, the square of your favorite number is {square}");
    }
}

// NOTES:
/* FUNCTIONS:

*** General format:
    returnType FunctionName(dataType parameter1, dataType parameter2)
    {
        // function_body
    }

*** Defining DATA TYPE for functions (return value) / parameters:
Examples:
    1. `void`: // means no data type for the function nor parameters are required
        void DisplayMessage()
        {
            Console.WriteLine("Hello world!");
        }

    2. Accepting parameters(s): single STRING:
        void DisplayPersonalMessage(string userName)
        {
            Console.WriteLine($"Hello {userName}");
        }

    3. Accepting parameters(s): two INTEGER
        int AddNumbers(int first, int second)
        {
            int sum = first + second;
            return sum;
        }

*** Standalone functions VS Member functions (a.k.a 'Methods'):
Examples: Standalone Functions:
    1. 
        static void DisplayMessage()
        {
            Console.WriteLine("Hello world!");
        }

    2.
        static void DisplayPersonalMessage(string userName)
        {
            Console.WriteLine($"Hello {userName}");
        }

    3.
        static int AddNumbers(int first, int second)
        {
            int sum = first + second;
            return sum;
        }

    NOTE: Until we start writing classes, you should put the static keyword in front of all your functions.
*/