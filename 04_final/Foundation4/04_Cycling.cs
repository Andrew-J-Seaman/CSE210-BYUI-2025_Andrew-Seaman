using System;

// ! Cycling subclass
public class Cycling : Activity
{
    private float _speed; // in kph

    public Cycling(string date, int minutes, float speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override float GetDistance()
    {
        return _speed * (GetMinutes() / 60f);
    }

    public override float GetSpeed()
    {
        return _speed;
    }

}
