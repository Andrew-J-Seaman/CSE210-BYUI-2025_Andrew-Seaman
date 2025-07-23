public class Lecture : Event
{
    // ATTRIBUTES
    private string _speaker;
    private int _capacity;


    // CONSTRUCTORS
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }


    // METHODS
    public override string GetFullDetails()
    {
        return $"Type: {base.ToString()}\nTitle: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
    
}