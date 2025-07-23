//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Eternal
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .....  0
        CONSTRUCTORS ...  2
        METHODS ........  2
——————————————————————————————————*/

using System;

namespace Develop05
{
    public class Eternal : Goal // derived class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Eternal(string title, string description, int rewardCheck) // Parameters: 3
            : base(title: title, description: description, rewardCheck: rewardCheck)       
        { }

        // C2....................................
        public Eternal(string title, string description, int checksActual, int rewardCheck) // Parameters: 4
            : base(title: title, description: description, checksActual: checksActual, rewardCheck: rewardCheck)
        { }

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // M1....................................
        // Called in 'Program.cs' to 'List Goals'.
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
        public override int RecordEvent()
        {
            SetChecksActual(GetChecksActual() + 1);
            return GetRewardCheck();
        }
    }
}