/* ORIGINAL CODE: Users.cs








// AUTHOR: Andrew Seaman
// TITLE: User Class
// DISCLOSURE: Development was aided by Chat GPT 4.0

using System;

public class User
{
    // Dictionary to store users with keys
    public Dictionary<int, string> _users { get; private set; }
    private const string userfFilePath = "/prove/Develop02/DataFiles/Users/Users.csv"; // '/Users/andrewseaman/Desktop/Fall '24_Desktop/CLS_P/Repository/CSE210_2024_AJS/prove/Develop02/DataFiles/Users/Users.csv'
    private const string incompleteUserFolderFilePath = "/prove/Develop02/DataFiles/Journals/User_"; // '/Users/andrewseaman/Desktop/Fall '24_Desktop/CLS_P/Repository/CSE210_2024_AJS/prove/Develop02/DataFiles/Journals/User_'
    public string _currentUserJournalFilePath;
    public string _currentUserPromptsFilePath;
    public int _currentUserID;

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
        // Print list of users
        Console.WriteLine("\nUsers:");
        foreach (var kvp in _users)
        {
            Console.WriteLine($"\t{kvp.Key}: {kvp.Value}");
        }

        int currentUserID;
        bool validUserID = false;

        // Loop until a valid user ID is entered
        do
        {
            // Ask user for their UserID
            Console.Write("\n\tEnter a user ID: ");

            // Try to parse the input as an integer
            if (int.TryParse(Console.ReadLine().Trim(), out currentUserID))
            {
                // Check if the entered ID exists in the dictionary
                if (_users.ContainsKey(currentUserID))
                {
                    validUserID = true;
                    UserFiles(currentUserID); // Call UserFiles method with the selected ID
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
        if (_users.TryGetValue(currentUserID, out string currentUserName))
        {
            currentUserName = currentUserName.Trim();

            if (currentUserName == "Empty")
            {
                Console.WriteLine("\n\tEnter new user name.");
                Console.Write($"\tFirst name: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write($"\tLast name: ");
                string lastName = Console.ReadLine().Trim();

                // Construct new user name from user's name inputs
                string newUserName = $"{firstName} {lastName}";

                // Update the _users dictionary with the new user name
                _users[currentUserID] = newUserName;

                // Write the updated user information back to the 'Users.csv'
                UpdateUsersFile(userfFilePath);

                Console.WriteLine($"\nWelcome {newUserName}, let's journal!\n");
            }
            else
            {
                Console.WriteLine($"\nWelcome {currentUserName}, let's journal!\n");
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
        _currentUserJournalFilePath = $"{completeUserFolderFilePath}/Journal.csv";
        _currentUserPromptsFilePath = $"{completeUserFolderFilePath}/Prompts.csv";
    }
}


*/