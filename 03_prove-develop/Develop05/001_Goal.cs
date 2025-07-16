//***********************************
// PROJECT: Eternal Quest (Develop05)
// CLASS: Goal
//***********************************

/* SECTION SUMMARY 
————————————————————————————————————
        ATTRIBUTES ..... 12
        CONSTRUCTORS ...  1
        METHODS ........  9
——————————————————————————————————*/

using System;

namespace Develop05
{
    // [Serializable]
    public abstract class Goal // abstract base class
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        // A1....................................
        protected string _title;
        // A2....................................
        // protected DateTime _creationDate;
        // A3....................................
        // protected string _checksFrequency;
        // A4....................................
        protected int _checksActual;
        // A5....................................
        protected int _checksTarget;
        // A6....................................
        // protected DateTime _targetDeadline;
        // A7....................................
        // protected bool _onTrack;
        // A8....................................
        protected int _rewardCheck;
        // A9....................................
        protected int _rewardTarget;
        // A10...................................
        protected int _rewardBonus;
        // A11...................................
        protected bool _status;
        // A12...................................
        // protected string _progress;

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
            string title = "none",
            // DateTime creationDate = default,
            // string checksFrequency = "none",
            int checksActual = 0,
            int checksTarget = 1,
            // DateTime targetDeadline = default,
            int rewardCheck = 0,
            int rewardTarget = 0,
            int rewardBonus = 0,
            bool status = false)
        {
            _title = title;
            // _creationDate = (creationDate == default) ? DateTime.Now : creationDate;
            // _checksFrequency = checksFrequency;
            _checksActual = checksActual;
            _checksTarget = checksTarget;
            // _targetDeadline = (targetDeadline == default) ? DateTime.Now.Date.AddDays(1) : targetDeadline;
            _rewardCheck = rewardCheck;
            _rewardTarget = rewardTarget;
            _rewardBonus = rewardBonus;
            _status = status;
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

        public int GetRewardBonus()
        {
            return _rewardBonus;
        }

        public bool GetStatus()
        {
            return _status;
        }

        // ————————————————————————————————————————————————————————————————————————————————————————
        // SETTERS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // NOTE: Each attribute needs to have a getter and setter so each goal object can be serialized and stored as a JSON object.

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

        // public void SetRewardBonus(int rewardBonus)
        // {
        //     _rewardBonus = rewardBonus;
        // }

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
        // public abstract string FormatProgress();

        // M2.................................... Q: Virtual not abstract?
        public virtual void RecordEvent()
        {

        }

        // M3.................................... Q: Virtual not abstract?
        public virtual int GetPoints()
        {

            return 0; // placeholder
        }

        // M4....................................
        public virtual void SetRewardBonus(int rewardBonus)
        {
            _rewardBonus = 0; // placeholder. For overrides: vary calculation.
        }

        // M5....................................
        public abstract void DisplayGoal(int i);

        // M6....................................
        public string FormatGoalOutput()
        {
            string d = "|";
            string line = $"{_title}{d}{_checksActual}{d}{_checksTarget}{d}{_rewardCheck}{d}{_rewardTarget}{d}{_rewardBonus}{d}{_status}";
            return line;
        }
    }
}
