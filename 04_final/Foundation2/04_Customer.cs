public class Customer
{
    // ATTRIBUTES
    private string _name;
    private Address _address;


    // CONSTRUCTORS
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }


    // METHODS
    public string GetCustomerInfo()
    {
        return $"   > {_name} \n{_address.GetAddress()}";
    }

}