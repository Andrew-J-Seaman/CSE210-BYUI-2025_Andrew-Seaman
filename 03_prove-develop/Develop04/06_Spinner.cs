//**********************************
// PROJECT: Mindfullness (Develop04)
//**********************************

namespace Develop04
{
    public class Spinner
    {
        //  *********************
        //      * SUMMARY*
        //
        //      ATTRIBUTES:   2
        //      INSTANCES:    0
        //      CONSTRUCTORS: 0
        //      METHODS:      3
        //  *********************

        // ATTRIBUTES...............................................................................(2)
        // A1. _sequence
        // A2. _currentFrame

        // A1.
        private string[] _sequence = { ".", "..", "...", " ..", " ." };

        // A2.
        private int _currentFrame = 0;

        // INSTANCES................................................................................(0)

        // CONSTRUCTORS.............................................................................(0)

        // METHODS..................................................................................(3)
        // M1. GetNextFrame
        // M2. Spin
        // M3. CountUpDown

        // M1.
        public string GetNextFrame() // Method to get the next spinner frame
        {
            string frame = _sequence[_currentFrame];
            _currentFrame = (_currentFrame + 1) % _sequence.Length; // Loop back to the first frame when the end is reached
            return frame;
        }

        // M2.
        public void Spin(int seconds)
        {
            DateTime end = DateTime.Now.AddSeconds(seconds);
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

        // M3.
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
}
