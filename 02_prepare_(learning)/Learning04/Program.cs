using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // OBJ: PROGRAM
        Program util = new Program();

        // OBJ: ASSIGNMENT
        Assignment asg = new Assignment("Andrew Seaman", "Long Division");
        util.NewLine();
        // EXPLICITLY call GetSummary() showing we understand derived classes inherit base class methods.
        Console.WriteLine(asg.GetSummary());

        // OBJ: MATH ASSIGNMENT
        MathAssignment mathAsg1 = new MathAssignment("Andrew Seaman", "Geometry", "8.3", "1-28");
        util.NewLine();
        // EXPLICITLY call GetSummary() showing we understand derived classes inherit base class methods.
        Console.WriteLine(mathAsg1.GetSummary());
        // Call GetHomeworkList() as normal because we've created an instance of MathAssignment
        Console.WriteLine(mathAsg1.GetHomeworkList());

        // OBJ: Writing ASSIGNMENT
        WritingAssignment writingAsg1 = new WritingAssignment(
            "Andrew Seaman",
            "The Rennaisance",
            "A Dive Into the Works of Shakespeare"
        );
        util.NewLine();
        // Call GetHomeworkList() as normal because we've created an instance of WritingAssignment.
        Console.WriteLine(writingAsg1.GetWritingInformation()); // IMPLICITLY calls GetSummary() showing we understand derived classes can use the keyword 'base' to call methods from the base class.
        util.NewLine();
    }

    private void NewLine()
    {
        Console.Write("\n");
    }
}
