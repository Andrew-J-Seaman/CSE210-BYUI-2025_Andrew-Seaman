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
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Checklist( string title, string description, int checksTarget, int rewardCheck, int rewardTarget )
            : base( title: title, description: description, checksTarget: checksTarget, rewardCheck: rewardCheck, rewardTarget: rewardTarget )
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