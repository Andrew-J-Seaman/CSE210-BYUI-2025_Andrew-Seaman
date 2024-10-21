using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class User
{
    // Dictionary to store users with keys
    public Dictionary<int, string> _users { get; private set; }
    private const string userfFilePath = "prove/Develop02/DataFiles/Users/Users.csv";
    private const string incompleteUserFolderFilePath = "prove/Develop02/DataFiles/Journals/User_";
    public string _userJournalFilePath;
    public string _userPromptsFilePath;

    // Constructor to initialize the users dictionary
    public User()
    {
        _users = LoadUsersFromCsvFile(userfFilePath);
    }

    // Method to read the 'Users.csv' file and load the users into a dictionary
    private Dictionary<int, string> LoadUsersFromCsvFile(string filePath)
    {
        var users = new Dictionary<int, string>();

        try
        {
            // Read all lines from the file and skip the first line if it contains headers
            var lines = File.ReadAllLines(filePath).Skip(1);

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

    public int DisplayUsersAndSelectOne()
    {
        // Variable used for indenting outputs
        string indent = "   >";

        // Print list of users
        Console.WriteLine("Users:");
        foreach (var kvp in _users)
        {
            Console.WriteLine($"{indent}{kvp.Key}: {kvp.Value}");
        }

        int currentUserID;
        bool validUserID = false;

        // Loop until a valid user ID is entered
        do
        {
            // Ask user for their UserID
            Console.WriteLine("\nEnter a user ID: ");
            
            // Try to parse the input as an integer
            if (int.TryParse(Console.ReadLine().Trim(), out currentUserID))
            {
                // Check if the entered ID exists in the dictionary
                if (_users.ContainsKey(currentUserID))
                {
                    validUserID = true;
                }
                else
                {
                    Console.WriteLine("Error: User ID not found. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid numeric ID.");
            }

        } while (!validUserID);

        return currentUserID;
    }

    public void GreetUserNewOrExisting(int currentUserID)
    {
        // Variable used for indenting outputs
        string indent = "   >";

        if (_users.TryGetValue(currentUserID, out string currentUserName))
        {
            currentUserName = currentUserName.Trim();

            if (currentUserName == "Empty")
            {
                Console.Write("Enter new user name.");
                Console.Write($"{indent}First name: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write($"{indent}Last name: ");
                string lastName = Console.ReadLine().Trim();

                // Construct new user name from user's name inputs
                string newUserName = $"{firstName} {lastName}";

                // Update the _users dictionary with the new user name
                _users[currentUserID] = newUserName;
                
                // Write the updated user information back to the 'Users.csv'
                UpdateUsersFile(userfFilePath);

                Console.WriteLine($"Welcome {newUserName}, let's journal!");
            }
            else
            {
                Console.WriteLine($"Welcome {currentUserName}, let's journal!");
            }
        }
        else
        {
            Console.WriteLine("Error: User ID not found.");
        }
    }

    // Method to write the updated users back to the 'Users.csv' file
    private void UpdateUsersFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("ID|Name"); // Add header if needed
                foreach (var kvp in _users)
                {
                    writer.WriteLine($"{kvp.Key}|{kvp.Value}");
                }
            }
            Console.WriteLine("User data successfully updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }

    public void UserFiles(int currentUserID)
    {
        string completeUserFolderFilePath = incompleteUserFolderFilePath + currentUserID;
        _userJournalFilePath = $"{completeUserFolderFilePath}/Journal.csv";
        _userPromptsFilePath = $"{completeUserFolderFilePath}/Prompts.csv";
    }

}