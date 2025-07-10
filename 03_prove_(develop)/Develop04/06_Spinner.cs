public class Spinner
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   3
    //      CONSTRUCTOR: 0
    //      METHOD:      4
    //  ******************

    // ATTRIBUTE        (3)

    // A1.
    private int _spinDuration;

    // A2.
    private string[] _sequence = { ".", "..", "...", " ..", " ." };

    // A3.
    private int _currentFrame = 0;

    // CONSTRUCTOR      (0)

    // METHOD           (4)

    // M1.
    public string GetNextFrame() // Method to get the next spinner frame
    {
        string frame = _sequence[_currentFrame];
        _currentFrame = (_currentFrame + 1) % _sequence.Length; // Loop back to the first frame when the end is reached
        return frame;
    }

    // M2.
    public void SetSpinDuration(int spinDuration)
    {
        // Set spin duration (in seconds)
        _spinDuration = spinDuration;
    }

    // M3.
    public void Spin()
    {
        DateTime end = DateTime.Now.AddSeconds(_spinDuration);
        while (DateTime.Now < end)
        {
            foreach (string frame in _sequence)
            {
                Console.Write($"\r{frame}   ");
                Thread.Sleep(200);
            }
        }
        Console.Write("\r          \r"); // Clear the line
    }

    // M4.
    public void CountUpDown(string msg1, string msg2)
    {
        int repeat = 5;

        Console.Write("     ");
        Console.Write(msg1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Green;
        for (int i = 0; i < repeat; i++)
        {
            Console.Write("___");
            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.Write("  ");

        Console.Write(msg2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Green;
        for (int i = 0; i < repeat; i++)
        {
            Console.Write("___");
            Thread.Sleep(1000);
        }
        Console.ResetColor();
    }
}
