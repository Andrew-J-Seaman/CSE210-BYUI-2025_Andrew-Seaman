//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Checklist
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
    public class Checklist : Goal // derived
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
        public Checklist(
            string title,
            int checksTarget,
            int rewardCheck,
            int rewardTarget
            )
            : base(
                title: title,
                checksTarget: checksTarget,
                rewardCheck: rewardCheck,
                rewardTarget: rewardTarget
                // type: base.ToString()
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
            string progress = _status ? "[x]" : $"[ {_checksActual} / {_checksTarget} ]";
            Console.WriteLine($"{i}. {progress} {_title}");
        }

        // M2....................................
        public override void RecordEvent()
        {

        }

        // M3....................................
        public override int GetPoints()
        {
            return 0; // placeholder
        }

    }
}