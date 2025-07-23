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
    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nRSVP Email: {_rsvpEmail}";
    }

}