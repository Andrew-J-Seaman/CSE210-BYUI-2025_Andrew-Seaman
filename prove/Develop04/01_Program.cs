using System;

class Program
{
    static void Main(string[] args)
    {
        // Loop main menu until user quits (option "4")
        bool quit = false;
        do
        {
            // Display menu and ask menu selection
            Console.Clear();
            Dictionary<int, string> menu = new Dictionary<int, string>()
            {
                { 1, "Breathing" },
                { 2, "Reflection" },
                { 3, "Listing" },
                { 4, "Quit" },
            };

            Console.WriteLine("MAIN MENU");
            foreach (KeyValuePair<int, string> kvp in menu)
            {
                Console.Write($"  {kvp.Key}. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{kvp.Value}");
                Console.ResetColor();
            }

            Thread.Sleep(300);
            Console.Write("\n  > Choose a number: ");
            string menu_selection = Console.ReadLine().Trim();

            // Apply valid menu selection. Loop if invalid.
            switch (menu_selection)
            {
                // Required parameters (case 1-3): Name, Description, Duration_Request

                case "1": // BREATHING
                    Breathing activity1 = new Breathing( // Name, Description, Duration Request Message
                        "Breathing",
                        "This activity will help you relax by walking your through breathing in and out slowly.\n   > Clear your mind and focus on your breathing.\n   > Per interval, you'll inhale for five seconds then exhale for five.",
                        "How many breathing intervals would you like (10 sec each)?"
                    );
                    activity1.RunBreathing();
                    break;

                case "2": // REFLECTION
                    Reflection activity2 = new Reflection( // Name, Description, Duration Request Message
                        "Reflection",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience.\n   > This will help you recognize the power you have and how you can use it in other aspects of your life. \n   > After considering the prompt you'll have 10 seconds per question to answer a series of questions to help you mentally articulate your thoughts. No input is required, just reflect on the questions.",
                        "How many questions (10 sec each) would you like to answer (max of 10)?"
                    );
                    activity2.RunReflection();
                    break;

                case "3": // LISTING
                    Listing activity3 = new Listing( // Name, Description, Duration Request Message
                        "Listing",
                        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                        "For how long would you like to list (seconds)?"
                    );
                    activity3.RunListing();
                    break;

                case "4": // QUIT
                    Console.Clear();
                    Console.WriteLine("Thank you for joining us for some relaxation. Farewell!");
                    quit = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine(
                        $"\nInvalid choice: (\"{menu_selection}\"). Please try again."
                    );
                    break;
            }
        } while (!quit);
    }
}
