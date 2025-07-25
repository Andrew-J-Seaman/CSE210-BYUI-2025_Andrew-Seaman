using System;

// ! Running subclass
public class Running : Activity
{
    private float _distance; // in km

    public Running(string date, int minutes, float distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override float GetDistance()
    {
        return _distance;
    }

}
