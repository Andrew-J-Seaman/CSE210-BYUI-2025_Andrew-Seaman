/* ************************************************************************************************
> |*  AUTHOR: Andrew Seaman
> |*  DATE: 2025-07-22
> |*  TITLE: Program 1: Abstraction with YouTube Videos
> |*  CLASS: Program

> |*  DISCLOSURE: Development was aided by Chat GPT
************************************************************************************************ */

// > Description:
/* 
    Scenario

        You have been hired by a company that does product awareness monitoring by tracking the placement of their products in YouTube videos. They want you to write a program that can help them work with the tens of thousands of videos they have identified as well as the comments on them.

    Program Specification

        Write a program to keep track of YouTube videos and comments left on them. As mentioned this could be part of a larger project to analyze them, but for this assignment, you will only need to worry about storing the information about a video and the comments.

        Your program should have a class for a Video that has the responsibility to track the title, author, and length (in seconds) of the video. Each video also has responsibility to store a list of comments, and should have a method to return the number of comments. A comment should be defined by the Comment class which has the responsibility for tracking both the name of the person who made the comment and the text of the comment.

        Once you have the classes in place, write a program that creates 3-4 videos, sets the appropriate values, and for each one add a list of 3-4 comments (with the commenter/'s name and text). Put each of these videos in a list.

        Then, have your program iterate through the list of videos and for each one, display the title, author, length, number of comments (from the method) and then list out all of the comments for that video. Repeat this display for each video in the list.

        Note: The YouTube example is just to give you a context for creating classes to store information. You will not actually be connecting to YouTube or downloading content in any way.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // * Video 1 ..............................................................................

        // New video
        Video video1 = new Video("Minecraft Speedrun in 30 Seconds", "Mr. Wobbles", 180);

        // Add comments
        video1.AddCommentUsingStrings("Jeff Nippard", "Great video!");
        video1.AddCommentUsingStrings("Mr. Wobbles", "Thanks for the video!");
        video1.AddCommentUsingStrings("Thomas Blue", "Great work as usual.");
        video1.AddCommentUsingStrings("Samantha Turnkey", "Thanks for another fun video.");

        // Display video
        Console.WriteLine("Video 1: \n");
        video1.DisplayVideo();
        Console.WriteLine("\n\n");

        // * Video 2 ..............................................................................

        // New video
        Video video2 = new Video("How to Build an Endermen Farm in Survival Minecraft", "Mr. Wobbles", 900);

        // Add comments
        video2.AddCommentUsingStrings("Jeff Nippard", "Great video!");
        video2.AddCommentUsingStrings("Mr. Wobbles", "Thanks for the video!");
        video2.AddCommentUsingStrings("Thomas Blue", "Great work as usual.");
        video2.AddCommentUsingStrings("Samantha Turnkey", "Thanks for another fun video.");

        // Display video
        Console.WriteLine("Video 2: \n");
        video2.DisplayVideo();
        Console.WriteLine("\n\n");

        // * Video 3 ..............................................................................

        // New video
        Video video3 = new Video("2 Hours of Raiding End Cities", "Mr. Wobbles", 7200);

        // Add comments
        video3.AddCommentUsingStrings("Jeff Nippard", "Great video!");
        video3.AddCommentUsingStrings("Mr. Wobbles", "Thanks for the video!");
        video3.AddCommentUsingStrings("Thomas Blue", "Great work as usual.");
        video3.AddCommentUsingStrings("Samantha Turnkey", "Thanks for another fun video.");

        // Display video
        Console.WriteLine("Video 3: \n");
        video3.DisplayVideo();
        Console.WriteLine("\n\n");

    }
}