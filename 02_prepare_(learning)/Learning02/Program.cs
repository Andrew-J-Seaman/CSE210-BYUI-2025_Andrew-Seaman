using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // Default greeting
        Console.WriteLine(">Hello Learning02 World!\n");

        // New: 'Job' instances:
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2012;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2019;
        job2._endYear = 2024;

        // New: 'Resume' instances:
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Print: name & job details
        myResume.Display();
    }
}
