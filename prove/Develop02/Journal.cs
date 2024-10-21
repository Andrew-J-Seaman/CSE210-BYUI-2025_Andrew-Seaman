using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

public class Journal
{
    // ATTRIBUTES //

    // Dictionary to store users with keys
    public Dictionary<int, string> _users { get; private set; }
    
    string _journalName;
    string _journalUsedPromptsIndex;
    string _journalPrompts;





    // METHODS //

        



    // Property to store users


    // Constructor to initialize the users dictionary
    public Journal()
    {
        _users = LoadUsersFromCsvFile("prove/Develop02/DataFiles/Users/Users.csv");
    }

    // Method to read the 'Users.csv' file and load the users into a dictionary
    private Dictionary<int, string> LoadUsersFromCsvFile(string filePath)
    {
        var users = new Dictionary<int, string>();

        try
        {
            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);

            // Loop through each line and add it to the dictionary
            foreach (var line in lines)
            {
                // Split the line by the pipe character '|'
                var parts = line.Split('|');

                // Ensure the line has exactly 2 parts: an ID and a name
                if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int userId))
                {
                    string userName = parts[1].Trim();
                    users[userId] = userName; // Add to the dictionary
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {line}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return users;
    }

    public display

    
}
