using System;

// ! Activity abstract base class
public abstract class Activity
{
    // ATTRIBUTES
    private string _date;
    private int _minutes;

    // CONSTRUCTORS
    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // METHODS
    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // -----

    public abstract float GetDistance(); // in km

    public virtual float GetSpeed()
    {
        return (GetDistance() / _minutes) * 60f;
    }

    public virtual float GetPace()
    {
        return _minutes / GetDistance();
    }

    // -----

    public string GetSummary()
    {
        string activityType = this.GetType().Name;
        return $"{_date} {activityType} ({_minutes} min) - Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}
