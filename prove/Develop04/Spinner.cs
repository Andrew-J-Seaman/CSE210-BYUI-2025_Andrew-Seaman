public class Spinner
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   1
    //      CONSTRUCTOR: 0
    //      METHOD:      2
    //  ******************

    // ATTRIBUTE        (1)

    // A1.
    private int _spinDuration;

    // CONSTRUCTOR      (0)

    // METHOD           (2)

    // M1.
    public void SetSpinDuration(int spinDuraiton)
    {
        _spinDuration = spinDuraiton;
    }

    // M2.
    public void Spin()
    {
        // PURPOSE: Whenever the application pauses it should show some kind of animation to the user, such as a spinner, a countdown timer, or periods being displayed to the screen.

        string[] sequence = { ".", "..", "...", " ..", " ." };
        DateTime end = DateTime.Now.AddSeconds(_spinDuration);

        while (DateTime.Now < end)
        {
            foreach (string frame in sequence)
            {
                Console.Write($"\r{frame}   ");
                Thread.Sleep(200);
            }
        }
        Console.Write("\r          \r"); // Clear the line
    }

    // M2.
    public void CountUpDown(string msg1, string msg2)
    {
        List<string> count = ["1", "2", "3", "4", "5"];

        Console.Write(msg1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Yellow;
        foreach (string number in count)
        {
            Console.Write(number);
            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.WriteLine("");

        Console.Write(msg2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Yellow;
        foreach (string number in count)
        {
            Console.Write(number);
            Thread.Sleep(1000);
        }
        Console.ResetColor();
    }
}
