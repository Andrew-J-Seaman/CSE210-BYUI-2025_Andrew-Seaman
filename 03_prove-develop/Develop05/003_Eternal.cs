//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Eternal
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .....  2
        CONSTRUCTORS ...  1
        METHODS ........  9
——————————————————————————————————*/

using System;

namespace Develop05
{
    public class Eternal : Goal // derived class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        // A1....................................
        private bool _streakStatus;
        // A2....................................
        private int _streakCurrent;
        // A3....................................
        private int _streakRecord;

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Eternal(string title, string checksFrequency, int checksTarget, DateTime targetDeadline, int rewardCheck, int rewardTarget)
        : base(title: title, checksFrequency: checksFrequency, checksTarget: checksTarget, targetDeadline: targetDeadline, rewardCheck: rewardCheck, rewardTarget: rewardTarget)
        {
            // Default values
            _streakStatus = false;
            _streakCurrent = 0;
            _streakRecord = 0;
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
        protected override void CheckProgress()
        {
            // Logic: calculate/formatt progress
            int streakTarget = _checksTarget;
            string progress = $"[ {_streakCurrent} / {streakTarget} ]"; // placeholder

            _progress = progress;

        }

        // M2....................................
        public override int GetPoints()
        {
            return 0; // placeholder (calculation)
        }
        
        // M3....................................
        public override void RecordEvent()
        {

        }

        // M4....................................
        public int GetTarget()
        {
            return 0; // placeholder
        }

        // M5....................................
        public void SetTarget(int target) // Explanation: only in the Eternal class would the user need to change the "_checksTarget" attribute for a goal as this goal subtype is the only one where a "completion streak" is considered as opposed to mere progress and completion status.
        {
            _checksTarget = target;
        }

        // M6....................................
        private void SetStreakStatus() // Determines if there is an active streak?
        {
            // Logic: active streak?
            // if (logic)
            // {
            //     _streakStatus = true;
            // }
            // else
            // {
            //     _streakStatus = false;
            // }
        }
        
        // M7....................................
        public override bool GetStatus() // GetStreakStatus
        {
            return _streakStatus;
        }

        // M8....................................
        public int GetStreakCurrent()
        {
            return _streakCurrent; // placeholder
        }

        // M9....................................
        public int GetStreakRecord()
        {
            return _streakRecord; // placeholder
        }

    }
}