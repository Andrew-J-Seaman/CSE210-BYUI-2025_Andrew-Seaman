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

        // Input: first name
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        
        // Input: last name
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();
        
        // Output: last, first last
        Console.WriteLine($"Hello {last}, {first} {last}");
    }
}