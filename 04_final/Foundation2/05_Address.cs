public class Address
{
    // ATTRIBUTES

    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _zip;
    private bool _isUSA;


    // CONSTRUCTORS

    public Address(string street, string city, string state, string country, string zip)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        _zip = zip;
        _isUSA = SetIsUSA();
    }


    // METHODS

    public bool GetIsUSA()
    {
        return _isUSA;
    }

    private bool SetIsUSA()
    {
        if (_country == "United States" || _country == "USA" || _country == "US")
        {
            _isUSA = true;
        }
        else
        {
            _isUSA = false;
        }
        return _isUSA;
    }  

    public string GetAddress()
    {
        return $"{_street} \n{_city} \n{_state} {_zip}, {_country}";
    } 

}