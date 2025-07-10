// FADE IN/OUT Logic:

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string message = "Hello, this is a fade-in and fade-out message!";
        FadeIn(message);
        Thread.Sleep(1000); // Pause before fading out
        FadeOut(message);
    }

    static void FadeIn(string message)
    {
        Console.Clear();
        for (int i = 1; i <= message.Length; i++)
        {
            Console.Write("\r" + message.Substring(0, i));
            Thread.Sleep(50); // Adjust speed for a slower or faster effect
        }
    }

    static void FadeOut(string message)
    {
        Console.Write("\r" + message);
        Thread.Sleep(500); // Pause briefly before starting fade-out
        for (int i = message.Length; i >= 0; i--)
        {
            Console.Write("\r" + message.Substring(0, i) + new string(' ', message.Length - i));
            Thread.Sleep(50); // Adjust speed for a slower or faster effect
        }
    }
}
