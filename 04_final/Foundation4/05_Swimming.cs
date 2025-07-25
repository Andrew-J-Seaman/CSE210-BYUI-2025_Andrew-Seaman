using System;

// ! Swimming subclass
public class Swimming : Activity
{
    // ATTRIBUTES
    private int _laps;

    // CONSTRUCTORS
    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // METHODS
    public override float GetDistance()
    {
        return (_laps * 50f) / 1000f; // meters to kilometers
    }

}
