public class Address
{
    // ATTRIBUTES

    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _zip;


    // CONSTRUCTORS

    public Address(string street, string city, string state, string country, string zip)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        _zip = zip;
    }


    // METHODS

    public string GetAddress()
    {
        return $"{_street} \n         {_city} \n         {_state} {_zip}, {_country}";
    } 

}