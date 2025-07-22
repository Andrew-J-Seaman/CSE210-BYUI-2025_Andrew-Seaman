//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Simple
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
    public class Simple : Goal // derived class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Simple(string title, string description, int rewardTarget)
            : base(title: title, description: description, rewardTarget: rewardTarget)
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
            string progress = _status ? "[x]" : "[ ]";
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


            return 0; // placeholder
        }


    }
}
