//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Simple
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .....  1
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
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Simple(
            string title,
            // DateTime targetDeadline,
            int rewardTarget
            )
            : base(
                title: title,
                // targetDeadline: targetDeadline,
                rewardTarget: rewardTarget
                )
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
        // Used in public base class method 'DisplayGoal' which is called in 'Program.cs' to 'List Goals'.
        public override void DisplayGoal(int i)
        {
            string progress = _status ? "[x]" : "[ ]";
            Console.WriteLine($"{i}. {progress} {_title}");
        }

        // M2....................................
        public override void RecordEvent()
        {

        }

        // M3....................................
        public override int GetPoints()
        {
            // Logic: calculate points

            return 0; // placeholder
        }


    }
}
