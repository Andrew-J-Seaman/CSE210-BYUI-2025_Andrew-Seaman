public class Product
{
    // ATTRIBUTES

    private string _name;
    private string _productId;
    private float _unitPrice;
    private int _quantity;


    // CONSTRUCTORS

    public Product(string name, string productId, float unitPrice, int quantity)
    {
        _name = name;
        _productId = productId;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }


    // METHODS

    public string GetProductInfo()
    {
        // A packing label should list the name and product id of each product in the order.
        return $"{_name} ({_productId})";
    }
    public float GetTotalCost()
    {
        return _unitPrice * _quantity;
    }

}
