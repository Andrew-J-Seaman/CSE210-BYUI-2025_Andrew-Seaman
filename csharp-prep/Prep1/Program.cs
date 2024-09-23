using System;

class Program
{
    static void Main(string[] args)
    {
//Default
        Console.WriteLine("Hello Prep1 World!");

//W01

    //Learning Activity - C# Prep 1
        //OBJ: Take input and print as output.

        // Input: {first name}
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();
        
        // Input: {last name}
        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();
        
        // Output: {first_name} & {last_name}
        Console.WriteLine($"First name: {first_name}");
        Console.WriteLine($"Last name: {last_name}");
    }
}