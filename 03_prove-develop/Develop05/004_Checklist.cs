//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Checklist
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
    public class Checklist : Goal // derived
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Checklist( string title, string description, int checksTarget, int rewardCheck, int rewardTarget ) // Parameters: 5
            : base( title: title, description: description, checksTarget: checksTarget, rewardCheck: rewardCheck, rewardTarget: rewardTarget )
        { }

        // C2....................................
        public Checklist( string title, string description, int checksActual, int checksTarget, int rewardCheck, int rewardTarget, bool status ) // Parameters: 7
            : base( title: title, description: description, checksActual: checksActual, checksTarget: checksTarget, rewardCheck: rewardCheck, rewardTarget: rewardTarget, status: status )
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
            string progress = _status ? "[x]" : $"[{_checksActual}/{_checksTarget}]";
            Console.WriteLine($"{i}. {progress} {_title}");
        }

        // M2....................................
        public override int RecordEvent()
        {
            SetChecksActual(GetChecksActual() + 1); // Increment checksActual
            int reward = GetRewardCheck();
            
            if (GetChecksActual() == GetChecksTarget()) // Did I meet my target?
            {
                SetStatus(true);
                reward += GetRewardTarget();
            }
        
            return reward;
        }

    }
}