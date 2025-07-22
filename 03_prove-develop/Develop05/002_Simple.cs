//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Simple
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
    // [Serializable]
    public class Simple : Goal // derived class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Simple(string title, string description, int rewardTarget) // Parameters: 3
            : base(title: title, description: description, rewardTarget: rewardTarget)
        { }

        // C2....................................
        public Simple(string title, string description, int rewardTarget, bool status) // Parameters: 4
            : base(title: title, description: description, rewardTarget: rewardTarget, status: status)
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
        public override int RecordEvent()
        {
            SetStatus(true);
            return GetRewardTarget();
        }

    }
}
