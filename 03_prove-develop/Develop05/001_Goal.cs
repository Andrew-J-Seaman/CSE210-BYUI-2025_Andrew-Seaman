//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Goal
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES .........  8
        CONSTRUCTORS .......  1
        METHODS:
            GETTERS ........  6
            SETTERS ........  6
            OTHER ..........  3
——————————————————————————————————*/

using System;

namespace Develop05
{
    public abstract class Goal // abstract base class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        // A1....................................
        protected string _title;
        // A2....................................
        protected string _description;
        // A3....................................
        protected string _type;
        // A4....................................
        protected int _checksActual;
        // A5....................................
        protected int _checksTarget;
        // A6....................................
        protected int _rewardCheck;
        // A7....................................
        protected int _rewardTarget;
        // A8...................................
        protected bool _status;

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Goal(
            // Default attribute values
            string title = "none",                  // A1
            string description = "none",            // A2
            int checksActual = 0,                   // A3
            int checksTarget = 1,                   // A4
            int rewardCheck = 0,                    // A5
            int rewardTarget = 0,                   // A6
            bool status = false,                    // A7
            string type = "none")                   // A8
        {
            // Attribute value assignments (initialization)
            _title = title;                  // A1
            _description = description;
            _checksActual = checksActual;
            _checksTarget = checksTarget;
            _rewardCheck = rewardCheck;
            _rewardTarget = rewardTarget;
            _status = status;
            _type = base.ToString().Split('.').Last();
        }

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // GETTERS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // NOTE: Each attribute needs to have a getter and setter so each goal object can be serialized and stored as a JSON object.
        // ! CORRECTION: This is not how you are meant to "provide a getter and setter" for each attribute" in order to serialize and store as a JSON object. You need to use " ... { get; set;}" after each attribute initialization in order to create a property and this is the first step of setting your classes so they can be serialized properly as JSON objects. Ergo, most of these getters and setters are unneccessary. (Note to self: Ignore this for now).

        public string GetTitle()
        {
            return _title;
        }

        public int GetChecksActual()
        {
            return _checksActual;
        }

        public int GetChecksTarget()
        {
            return _checksTarget;
        }

        public int GetRewardCheck()
        {
            return _rewardCheck;
        }

        public int GetRewardTarget()
        {
            return _rewardTarget;
        }

        public bool GetStatus()
        {
            return _status;
        }

        // ————————————————————————————————————————————————————————————————————————————————————————
        // SETTERS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // NOTE: Each attribute needs to have a getter and setter so each goal object can be serialized and stored as a JSON object.
        // ! CORRECTION: *** see note above in the GETTERS section ***

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void SetChecksActual(int checksActual)
        {
            _checksActual = checksActual;
        }

        public void SetChecksTarget(int checksTarget)
        {
            _checksTarget = checksTarget;
        }

        public void SetRewardCheck(int rewardCheck)
        {
            _rewardCheck = rewardCheck;
        }

        public void SetRewardTarget(int rewardTarget)
        {
            _rewardTarget = rewardTarget;
        }

        public void SetStatus(bool status)
        {
            _status = status;
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
        public abstract void DisplayGoal(int i);

        // M2....................................
        public abstract int RecordEvent();

        // M3....................................
        public string FormatGoalOutput()
        {
            string d = "|";
            string formatted_goal = $"{_title}{d}{_description}{d}{_type}{d}{_checksActual}{d}{_checksTarget}{d}{_rewardCheck}{d}{_rewardTarget}{d}{_status}";
            return formatted_goal;
        }
        
    }

}
