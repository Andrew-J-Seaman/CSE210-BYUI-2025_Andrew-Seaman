class Program
{
    static void Main(string[] args)
    {
        // Create a new Circle object and set and display it's radius
        Circle myCircle = new Circle();
        myCircle.SetRadius(10);
        Console.WriteLine($"The radius of the circle is {myCircle.GetRadius()}");
        // Create a second new Circle object and set and display it's radius
        Circle myCircle2 = new Circle();
        myCircle2.SetRadius(20);
        Console.WriteLine($"The radius of the circle is {myCircle2.GetRadius()}");

        // Display the area of the circle
        Console.WriteLine($"The area of the first circle is {myCircle.GetArea()}");
        Console.WriteLine($"The area of the second circle is {myCircle2.GetArea()}");
    }
}

class Circle
{
    // Property to store the radius of the circle
    private double _radius;

    // Method to set the radius of the circle
    public void SetRadius(double radius)
    {
        if (radius < 0)
        {
            Console.WriteLine("Error: Radius cannot be negative.");
            return;
        }
        _radius = radius;
    }
    // Method to get the radius of the circle
    public double GetRadius()
    {
        return _radius;
    }

    // Method to calculate the area of the circle
    public double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}
