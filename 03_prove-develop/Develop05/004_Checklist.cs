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
        public Checklist(string title, string checksFrequency, int checksTarget, DateTime targetDeadline, int rewardCheck, int rewardTarget)
        : base(title: title, checksFrequency: checksFrequency, checksTarget: checksTarget, targetDeadline: targetDeadline, rewardCheck: rewardCheck, rewardTarget: rewardTarget)
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
            // Logic: calculate/formatt progress
            string progress = $"[ {_checksActual} / {_checksTarget} ]"; // placeholder

            _progress = progress;

        }

        // M2....................................
        public override int GetPoints()
        {
            return 0; // placeholder
        }

        // M3....................................
        public override void RecordEvent()
        {

        }
        
    }
}