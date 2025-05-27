// ---
// Author: "Brother Goderidge"
// Date "2025-05-27"
// Title: "In-class Tutorial: Creating a New C# Project and Class"
// ---

using System;

class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Bounjour tout le monde!");

        WordCounter wordCounter = new WordCounter(
            "This is a test sentence to allow testing my new class."
        );
    }
}
