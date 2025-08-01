/* ************************************************************************************************
> AUTHOR: Andrew Seaman
> DATE: 2025-07-22
> TITLE: Program 4: Polymorphism with Exercise Tracking
> CLASS: Program

> DISCLOSURE: Development was aided by Chat GPT
************************************************************************************************ */

// > Description:
/*
    Scenario
        The local fitness center has hired you to write an app for their customers to track their exercise. They have facilities for the following:

        • Running
        • Stationary Bicycles
        • Swimming in the lap pool
        
        For each activity, they want to track the the date and the length of the activity in minutes. Then, for each activity, they would like to also track the following:

        • Running: distance
        • Cycling: speed
        • Swimming: number of laps
        
        For each activity, they do not want to store this information, but they would like to be able to get following information (by calculation if it is not stored directly):

        • The distance
        • The speed (miles per hour or kilometers per hour)
        • The pace (minutes per mile or minutes per kilometer)
        • A summary in the form of:
            - 03 Nov 2022 Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile
            - 03 Nov 2022 Running (30 min): Distance 4.8 km, Speed: 9.6 kph, Pace: 6.25 min per km
        
        You may choose if your program uses miles or kilometers (you do not need to handle both). In either case the length of a lap in the lap pool is 50 meters.

    Program Specification

        Write a program that has a base Activity class and then has a derived class for each of the three activities. The base class should contain any attributes that are shared among all activities. Then, each derived class can define any additional attributes.

        In addition, the base class should contain virtual methods for getting the distance, speed, pace. These methods should be overridden in the derived classes.

        Finally, you should provide a GetSummary method to produce a string with all the summary information.
        Remember that the summary method can make use of the other methods to produce its result. This method should be available for all classes, so it should be defined in the base class (you can override it in the derived classes if needed, but it may not need to be...).

        Once you have the classes in place, write a program that creates at least one activity of each type. Put each of these activities in the same list. Then iterate through this list and call the GetSummary method on each item and display the results.

        In addition, your program must:

        1. Use inheritance to avoid duplicating shared attributes and methods.
        2. Use method overriding for the calculation methods.
        3. Follow the principles of encapsulation, making sure each member variable is private.
        
    Math Hints:
        • Distance (km) = swimming laps * 50 / 1000
        • Distance (miles) = swimming laps * 50 / 1000 * 0.62
        • Speed (mph or kph) = (distance / minutes) * 60
        • Pace (min per mile or min per km)= minutes / distance
        • Speed = 60 / pace
        • Pace = 60 / speed
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // New activies
        Running running1 = new Running("03 Nov 2022", 30, 3.0f);
        Cycling cycling1 = new Cycling("03 Nov 2022", 30, 6.0f);
        Swimming swimming1 = new Swimming("03 Nov 2022", 30, 5);

        // Add activies to list
        List<Activity> activities = new List<Activity>();
        activities.Add(running1);
        activities.Add(cycling1);
        activities.Add(swimming1);

        // Clear console
        Console.Clear();

        // Display header
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;

        string header = "Activity Summary:".ToUpper();
        string paddedHeader = header.PadRight(95); // Pads the rest with spaces to reach 80 chars
        Console.Write(paddedHeader);

        Console.ResetColor();
        
        Console.WriteLine(); // New line without alternate background color

        // Display summary for each activity
        int index = 1;
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"{index}.   {activity.GetSummary()}");
            index++;
        }

    }

}
