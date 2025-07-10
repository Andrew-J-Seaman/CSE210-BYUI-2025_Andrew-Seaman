using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize User object
        User user = new User();
        int currentUserID = user.DisplayUsersAndSelectOne();
        user.GreetUserWhoIsNewOrExisting(currentUserID);
        string jfp = user._userJournalFilePath;
        string pfp = user._userPromptsFilePath;






    }
}