using System;
using System.Formats.Asn1;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;

// OBJECTIVE: create grading system
        /** Criteria:
            A >= 90
            B >= 80
            C >= 70
            D >= 60
            F < 60
        **/

class Program
{
    static void Main(string[] args)
    {
    // Greeting
        Console.Clear();
        Console.WriteLine("> Hello student!");
    
    // Initialize some variables
        string  letter = "";
        int     percent = 0;
        string  passOrFail;
        string  letterSymbol;
        bool    validpercent = false;
        
    // Ask user for input
        while (!validpercent)
        {
            Console.Write("> What is your grade percentage?\n   > ");
            percent = int.Parse(Console.ReadLine());

            if (percent > 0 && percent < 200) 
                {validpercent = true;}
            else
                {Console.WriteLine("\n> Invalid grade percentage. Enter a value 0-200.\n");}
        }

    // Set variables based on user input
        string percentString = percent.ToString();
        int lastChar = percentString[percentString.Length - 1];
        
    // Letter grade
        if (percent >= 90)
            {letter = "A";}
        else if (percent >= 80)
            {letter = "B";}
        else if (percent >= 70)
            {letter = "C";}
        else if (percent >= 60)
            {letter = "D";}
        else if (percent <= 59)
            {letter = "F";}

    // Pass or fail
        if (percent < 70)
            {passOrFail = "PASSED";}
        else 
            {passOrFail = "FAILED";}

    // + or –
        if (lastChar >= 7)
            {letterSymbol = "+";}
        else if (lastChar < 3)
            {letterSymbol = "-";}
        else
            {letterSymbol = "";}

    // Final output
        Console.WriteLine($"> You {passOrFail} with a {letter}{letterSymbol}.");
    }
}