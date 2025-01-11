using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

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
        string _letter = "";
        int _percent = 0;
        string _passOrFail;
        string _congratsOrSympathies;
        string _letterSymbol;
        string _properArticle;
        bool _validPercent = false;
        // Set variables based on verified user input
        string percentString = _percent.ToString();
        int lastChar = percentString[percentString.Length - 1];


        // Ask user for input
        while (!_validPercent)
        {
            Console.Write("> What is your grade percentage?\n   > ");
            _percent = int.Parse(Console.ReadLine());

            if (_percent > 0 && _percent < 200)
            {
                _validPercent = true;
            }
            else
            {
                Console.WriteLine("> ERROR: Invalid grade percentage. Enter a value 0-200.\n");
            }
        }



        // _letter grade
        if (_percent >= 90)
        {
            _letter = "A";
        }
        else if (_percent >= 80)
        {
            _letter = "B";
        }
        else if (_percent >= 70)
        {
            _letter = "C";
        }
        else if (_percent >= 60)
        {
            _letter = "D";
        }
        else if (_percent <= 59)
        {
            _letter = "F";
        }

        // Pass or fail
        if (_percent >= 60)
        {
            _passOrFail = "PASSED";
            _congratsOrSympathies = "Congrats! You";
        }
        else
        {
            _passOrFail = "FAILED";
            _congratsOrSympathies = "Our sympathies, you";
        }

        // + or –
        if (lastChar >= 7 && _letter != "A" && _letter != "F")
        {
            _letterSymbol = "+";
        }
        else if (lastChar < 3 && _letter != "F")
        {
            _letterSymbol = "-";
        }
        else
        {
            _letterSymbol = "";
        }

        // Proper article
        if (_letter == "A" || _letter == "F")
        {
            _properArticle = "an";
        }
        else
        {
            _properArticle = "a";
        }



        // Final output
        Console.WriteLine(
            $"> {_congratsOrSympathies} [{_passOrFail}] with {_properArticle} [{_letter}{_letterSymbol}]!"
        );
    }
}
