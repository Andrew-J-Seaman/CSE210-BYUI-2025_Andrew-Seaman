using System;

class Program
{
    static void Main(string[] args)
    {
        // Activity activity = new Activity("Test_Name", "Test_Description", "Test_duration_request");
        // activity.BouncingDotSpinner(30);






    
        // Loop main menu until user quits (option "4")
        bool quit = false;
        do 
        {
            // Display menu and ask menu selection
            Console.Clear();
            Console.WriteLine
            (
                "Menu Options    \n"    +

                "  1. Breathing  \n"    +
                "  2. Reflecting \n"    +
                "  3. Listing    \n"    +
                "  4. Quit       \n"
            );
            Thread.Sleep(300);
            Console.Write("> Select number: ");
            string menu_selection = Console.ReadLine().Trim();

            // Apply valid menu selection. Loop if invalid.
            switch (menu_selection)
            {
                // Required parameters (case 1-3): Name, Description, Duration_Request

                case "1":     // BREATHING
                    Breathing act1 = new Breathing(
                        "Breathing", 
                        "This activity will help you relax by walking your through breathing in and out slowly.\n   > Clear your mind and focus on your breathing.\n   > Per interval, you'll inhale for five seconds, hold for two, and exhale for three.", 
                        "How many intervals (10 sec) would you like?"
                    );
                    act1.RunBreathing();
                    break;

                case "2":     // REFLECTING
                    Reflecting act2 = new Reflecting(
                        "Reflecting", 
                        "This activity will help you reflect on times in your life when you have shown strength and resilience.\n   > This will help you recognize the power you have and how you can use it in other aspects of your life. \n   > After considering the prompt you'll have 10 seconds to answer a series of questions to help you articulate your thoughts.", 
                        "How many questions (10 sec) would you like to answer?"
                    );
                    act2.RunReflecting();                   
                    break;
 
                case "3":     // LISTING
                    Listing act3 = new Listing(
                        "Listing", 
                        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 
                        "For how long would you like to list (seconds)?"
                    );
                    act3.RunListing();                    
                    break;

                case "4":     // QUIT
                    Console.Clear();
                    Console.WriteLine("Thank you for joining us for some relaxation. Farewell!");
                    quit = true;
                    break;
                
                default:
                    Console.Clear();
                    Console.WriteLine($"\nInvalid selection (\"{menu_selection}\"). Please try again.");
                    break;
            }
        } while (!quit);
    
    }
}