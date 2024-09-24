using System;
using System.Formats.Asn1;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
//OBJ: create grading system
/**
A >= 90
B >= 80
C >= 70
D >= 60
F < 60
**/

        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();

        string grade = "";

        try
        {
            int percent = int.Parse(userInput);

            if (percent >= 90)
            {
                grade = "A";
            }
            else if (percent >= 80)
            {
                grade = "B";
            }
            else if (percent >= 70)
            {
                grade = "C";
            }
            else if (percent >= 60)
            {
                grade = "D";
            }
            else if (percent < 60)
            {
                grade = "F";
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("That's not a valid number. Please enter a numeric value.");
        }
        Console.WriteLine($"You're grade is {grade}.");
    }
}