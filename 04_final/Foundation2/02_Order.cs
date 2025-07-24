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
    
    public void GetTotalPrice(Address address)
    {
        float totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
            if (address.GetIsUSA())
            {
                totalCost += 5;
            }
            else
            {
                totalCost += 35;
            }
        }
        Console.WriteLine($"${totalCost}\n\n\n"); // This is the total price
    }

}