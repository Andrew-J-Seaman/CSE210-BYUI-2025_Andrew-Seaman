using System;
using System.Formats.Asn1;
using System.Net.Sockets;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        //OBJ: create grading system
        /** Criteria:
        A >= 90
        B >= 80
        C >= 70
        D >= 60
        F < 60
        **/

        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();

        string letter = "";
        int percent = 0;
        bool passed = true;

        try
        {
            percent = int.Parse(userInput);

            if (percent >= 90)
            {
                letter = "A";
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else if (percent < 60)
            {
                letter = "F";
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("That's not a valid number. Please enter a numeric value.");
        }

        if (percent < 70)
        {
            passed = false;
        }

        if (passed == true)
        {
            Console.WriteLine($"You passed with a {letter}.");
        }
        else
        {
            Console.WriteLine($"You failed with a {letter}.");
        }
    }
}