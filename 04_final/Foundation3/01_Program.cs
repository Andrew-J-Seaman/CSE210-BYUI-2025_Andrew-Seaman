/* ************************************************************************************************
> |*  AUTHOR: Andrew Seaman
> |*  DATE: 2025-07-22
> |*  TITLE: Program 3: Inheritance with Event Planning
> |*  CLASS: Program

> |*  DISCLOSURE: Development was aided by Chat GPT
************************************************************************************************ */

// > Description:
/* 
    Scenario

        You have been hired by an event planning company. They help organize and market events throughout the world. They need you to write a program to track each of these events and produce the marketing material to distribute on social media. They typically handle a few main types of events:

        • Lectures, which have a speaker and have a limited capacity.
        • Receptions, which require people to RSVP, or register, beforehand.
        • Outdoor gatherings, which do not have a limit on attendees, but need to track the weather forecast.
    
    Regardless of the type, all events need to have an Event Title, Description, Date, Time, and Address.

    They would like the ability to generate three different messages:

        1. Standard details - Lists the title, description, date, time, and address.
        2. Full details - Lists all of the above, plus type of event and information specific to that event type. For lectures, this includes the speaker name and capacity. For receptions this includes an email for RSVP. For outdoor gatherings, this includes a statement of the weather.
        3. Short description - Lists the type of event, title, and the date.
    
    Program Specification

        Write a program that has a base Event class along with derived classes for each type of event. These classes should contain the necessary data and provide methods to return strings for each of the messages the company desires.

        Remember that any data or methods that are common among all types of events should be in the base class.

        Once you have the classes in place, write a program that creates at least one event of each type and sets all of their values. Then, for event event, call each of the methods to generate the marketing messages and output their results to the screen.

        In addition, your program must:

            1. Use inheritance to avoid duplicating shared attributes and methods.
            2. Use an address class for the addresses.
            3. Follow the principles of encapsulation, making sure each member variable is private.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // > 1. Create a list of events (one of each derived type)

        // ! I opted for 24hr time to keep (global) timing consistent.

        List<Event> events = new List<Event>();

        // * Lecture (event) ......................................................................
        Lecture lecture = new Lecture(
            "Mastering AI Tools",
            "An in-depth lecture on leveraging generative AI in business workflows.",
            "2025-09-12",
            "14:00",
            new Address("456 Innovation Way", "San Francisco", "CA", "USA", "94110"),
            "Dr. Elaine Ramos",
            250);
        events.Add(lecture);

        // * Reception (event) ....................................................................
        Reception reception = new Reception(
            "Startup Networking Mixer",
            "Join local entrepreneurs and investors for an evening of connections.",
            "2025-09-15",
            "18:30",
            new Address("99 Market St", "Austin", "TX", "USA", "78701"),
            "rsvp@startupmixer.com");
        events.Add(reception);

        // * OutdoorGathering (event) .............................................................
        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Autumn Food Festival",
            "Celebrate local cuisine with food trucks, live music, and family fun.",
            "2025-10-01",
            "12:00",
            new Address("500 Park Ave", "Boulder", "CO", "USA", "80301"),
            "Sunny with light breeze");
        events.Add(outdoorGathering);

        // > 2. Display each event's standard details

        DisplayHeader("Standard Details");
        foreach (Event e in events)
        {
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();
        }

        // > 3. Display each event's full details

        DisplayHeader("Full Details");
        foreach (Event e in events)
        {
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
        }

        // > 4. Display each event's short description  

        DisplayHeader("Short Description");
        foreach (Event e in events)
        {
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();
        }
    }

    public static void DisplayHeader(string header)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;

        string line = $"{header.ToUpper()}:";
        line = line.PadRight(83); // Pads the rest with spaces to reach 80 chars
        Console.Write(line);

        Console.ResetColor();

        Console.WriteLine();
    }
}