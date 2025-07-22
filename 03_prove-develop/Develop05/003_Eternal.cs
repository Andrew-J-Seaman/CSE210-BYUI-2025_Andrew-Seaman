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
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Eternal(string title, string description, int rewardCheck)
            : base(title: title, description: description, rewardCheck: rewardCheck)       
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
        public override void RecordEvent()
        {
            // Logic: record event

        }

        // M3....................................
        public override int GetPoints()
        {
            // Logic: calculate points

            
            return 0; // placeholder (calculation)
        }
    }
}