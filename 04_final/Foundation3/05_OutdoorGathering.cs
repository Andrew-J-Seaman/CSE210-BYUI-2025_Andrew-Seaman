public class OutdoorGathering : Event
{
    // ATTRIBUTES
    private string _weather;


    // CONSTRUCTORS
    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }


    // METHODS
    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather: {_weather}";
    }

}