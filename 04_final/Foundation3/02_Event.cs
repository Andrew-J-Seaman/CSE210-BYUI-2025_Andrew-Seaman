public class Event // Base class
{
    // ATTRIBUTES

    public string _title;
    public string _description;
    public string _date;
    public string _time;
    public Address _address;


    // CONSTRUCTORS

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }


    // METHODS

    public string GetStandardDetails()
    {   // Note: This comment below relies on line wrapping being turned off to display correclty.
        //              1                      2                     3              4                 5
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"Type: {GetType()}\nTitle: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}";
    }

    public string GetShortDescription()
    {
        
        return $"Type: {GetType()}\nTitle: {_title}\nDate: {_date}";
    }

    public string GetType()
    {
        string type;
        if (base.ToString() == "OutdoorGathering")
        {
            type = "Outdoor Gathering";
        }
        else
        {
            type = base.ToString();
        }
        return type;
    }
}