public class Outdoor : Event
{
    // ATTRIBUTES
    private string _weather;


    // CONSTRUCTORS
    public Outdoor(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }


    // METHODS
    public string GetFullDetails()
    {
        return $"Type: {base.ToString()}\nTitle: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}\nWeather: {_weather}";
    }

}