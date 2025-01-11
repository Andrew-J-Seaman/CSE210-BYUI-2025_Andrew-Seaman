using System;

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
    
    // Initialize  variables
        string  letter = "";
        int     percent = 0;
        string  passOrFail;
        string  congratsOrSympathies;
        string  letterSymbol;
        string  properArticle;
        bool    validPercent = false;
        
    // Ask user for input
        while (!validPercent)
        {
            Console.Write("> What is your grade percentage?\n   > ");
            percent = int.Parse(Console.ReadLine());

            if (percent > 0 && percent < 200) 
                {validPercent = true;}
            else
                {Console.WriteLine("> ERROR: Invalid grade percentage. Enter a value 0-200.\n");}
        }

    // Set variables based on verified user input
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
        if (percent >= 60)
            {passOrFail = "PASSED";
            congratsOrSympathies = "Congrats! You";}
        else 
            {passOrFail = "FAILED";
            congratsOrSympathies = "Our sympathies, you";}

    // + or –
        if (lastChar >= 7 && letter != "A" && letter != "F")
            {letterSymbol = "+";}
        else if (lastChar < 3 && letter != "F")
            {letterSymbol = "-";}
        else
            {letterSymbol = "";}

    // Proper article
        if (letter == "A" || letter == "F")
            {properArticle = "an";}
        else
            {properArticle = "a";}
    // Final output
        Console.WriteLine($"> {congratsOrSympathies} {passOrFail} with {properArticle} {letter}{letterSymbol}.");
    }
}

