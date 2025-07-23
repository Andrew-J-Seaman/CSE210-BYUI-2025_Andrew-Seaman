public class Order
{
    // ATTRIBUTES
    private List<Product> _products;
    private Customer _customer;


    // CONSTRUCTORS
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }


    // METHODS

    public void AddProduct(string name, string productId, float unitPrice, int quantity)
    {
        Product product = new Product(name, productId, unitPrice, quantity);
        _products.Add(product);
    }

    // Labels:

    public void GetPackingLabel()
    {
        foreach (Product product in _products)
        {
            Console.WriteLine($"   > {product.GetProductInfo()}"); // Console.WriteLine(product.GetProductInfo());
        }
    }

    public void GetShippingLabel()
    {
        Console.WriteLine(_customer.GetCustomerInfo());
    }
    
    public float GetTotalPrice()
    {
        float totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        return totalCost; // This is the total price
    }

}