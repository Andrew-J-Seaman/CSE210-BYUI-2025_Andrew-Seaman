//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Simple
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .....  1
        CONSTRUCTORS ...  1
        METHODS ........  6
——————————————————————————————————*/

using System;

namespace Develop05
{
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
        public Simple(string title, DateTime targetDeadline, int rewardTarget)
        : base(title: title, targetDeadline: targetDeadline, rewardTarget: rewardTarget)
        {}

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // M1....................................
        protected override void CheckProgress()
        {
            // Logic: conditionally format progress
            string marker = (_status) ? "x" : " ";
            string progress = $"[{marker}]"; // placeholder
            _progress = progress;
        }

        // M2....................................
        public override int GetPoints()
        {
            // Logic: calculate points

            return 0; // placeholder
        }
        
        // M3....................................
        public override void RecordEvent()
        {

        }
        
        // M4....................................
        public void SetStatus()
        {

        }
        
        // M5....................................
        public void SetTargetDeadline(DateTime deadline)
        {

        }

    }
}
