//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Eternal
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .....  0
        CONSTRUCTORS ...  1
        METHODS ........  3
——————————————————————————————————*/

using System;

namespace Develop05
{
    // [Serializable]
    public class Eternal : Goal // derived class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        // A1....................................
        // private int _streakCurrent;
        // A2....................................
        // private int _streakRecord;

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Eternal(
            string title,
            // string checksFrequency, 
            // int checksTarget, 
            // DateTime targetDeadline, 
            int rewardCheck,
            int rewardTarget
            )
            : base(
                title: title,
                // checksFrequency: checksFrequency,
                // checksTarget: checksTarget,
                // targetDeadline: targetDeadline,
                rewardCheck: rewardCheck,
                rewardTarget: rewardTarget)
        {
            // Default values
            // _streakStatus = false;
            // _streakCurrent = 0;
            // _streakRecord = 0;
        }

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // M1....................................
        // Used in public base class method 'DisplayGoal' which is called in 'Program.cs' to 'List Goals'.
        public override void DisplayGoal(int i)
        {
            string insideText;
            if (_checksActual == 0)
            {
                insideText = " ";
            }
            else
            {
                insideText = _checksActual.ToString();
            }

            string progress = $"[{insideText}]";
            Console.WriteLine($"{i}. {progress} {_title}");
        }

        // M2....................................
        public override void RecordEvent()
        {

        }

        // M3....................................
        public override int GetPoints()
        {
            return 0; // placeholder (calculation)
        }
    }
}