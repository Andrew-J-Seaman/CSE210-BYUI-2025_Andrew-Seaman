public class Reception : Event
{
    // MEMBERS
    private string _rsvpEmail;


    // CONSTRUCTORS
    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }


    // METHODS
    public string GetFullDetails()
    {
        return $"Type: {base.ToString()}\nTitle: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}\nRSVP Email: {_rsvpEmail}";
    }

}