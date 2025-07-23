/* ************************************************************************************************
> |*  AUTHOR: Andrew Seaman
> |*  DATE: 2025-07-22
> |*  TITLE: Program 2: Encapsulation with Online Ordering
> |*  CLASS: Program

> |*  DISCLOSURE: Development was aided by Chat GPT
************************************************************************************************ */

// > Description:
/* 
    Scenario

        You have been hired to help a company with their product ordering system. They sell many products online to a variety of customers and need to produce packing labels, shipping labels, and compute final prices for billing.

    Program Specification

        Write a program that has classes for Product, Customer, Address, and Order. The responsibilities of these classes are as follows:

            > Order

                • Contains a list of products and a customer. Can calculate the total cost of the order. Can return a string for the packing label. Can return a string for the shipping label.
                • The total price is calculated as the sum of the total cost of each product plus a one-time shipping cost.
                • This company is based in the USA. If the customer lives in the USA, then the shipping cost is $5. If the customer does not live in the USA, then the shipping cost is $35.
                • A packing label should list the name and product id of each product in the order.
                • A shipping label should list the name and address of the customer

            > Product

                • Contains the name, product id, price per unit, and quantity of each product.
                • The total cost of this product is computed by multiplying the price per unit and the quantity. If the price per unit was $3 and they bought 5, the product total cost would be $15.

            > Customer

                • The customer contains a name and an address.
                • The name is a string, but the Address is a class.
                • The customer should have a method that can return whether they live in the USA or not. (Hint this should call a method on the address to find this.)

            > Address

                • The address contains a string for the street address, the city, state/province, and country.
                • The address should have a method that can return whether it is in the USA or not.
                • The address should have a method to return a string all of its fields together in one string (with newline characters where appropriate)

        Other considerations

            Make sure that all member variables are private and getters, setters, and constructors are created as needed.

            Once you have created these classes, write a program that creates at least two orders with a 2-3 products each. Call the methods to get the packing label, the shipping label, and the total price of the order, and display the results of these methods.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // ! TESTING !

        // * Order 1 ..............................................................................

        Console.WriteLine("Order 1:\n—————————————————————————————");

        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA", "83440");

        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct("Wireless Mouse", "WM101", 25, 2);
        order1.AddProduct("Mechanical Keyboard", "MK202", 80, 1);
        order1.AddProduct("USB-C Hub", "UH303", 40, 3);

        Console.WriteLine($"Packing Label:");
        order1.GetPackingLabel();

        Console.WriteLine($"\nShipping Label:");
        order1.GetShippingLabel();

        Console.Write($"\nTotal Price: ");
        order1.GetTotalPrice();

        // * Order 2 ..............................................................................

        Console.WriteLine("Order 2:\n—————————————————————————————");

        Address address2 = new Address("123 Main St", "Anytown", "CA", "USA", "83440");

        Customer customer2 = new Customer("John Doe", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct("Noise Cancelling Headphones", "NC404", 150, 1);
        order2.AddProduct("Webcam 1080p", "WC505", 60, 2);
        order2.AddProduct("Laptop Stand", "LS606", 35, 2);

        Console.WriteLine($"Packing Label:");
        order2.GetPackingLabel();

        Console.WriteLine($"\nShipping Label:");
        order2.GetShippingLabel();

        Console.Write($"\nTotal Price: ");
        order2.GetTotalPrice();

        // * Order 3 ..............................................................................

        Console.WriteLine("Order 3:\n—————————————————————————————");

        Address address3 = new Address("123 Main St", "Anytown", "CA", "USA", "83440");

        Customer customer3 = new Customer("John Doe", address3);

        Order order3 = new Order(customer3);

        order3.AddProduct("Portable SSD", "PS707", 120, 1);
        order3.AddProduct("Bluetooth Speaker", "BS808", 75, 2);
        order3.AddProduct("Wireless Charger", "WC909", 30, 3);

        Console.WriteLine($"Packing Label:");
        order3.GetPackingLabel();

        Console.WriteLine($"\nShipping Label:");
        order3.GetShippingLabel();

        Console.Write($"\nTotal Price: ");
        order3.GetTotalPrice();


    }
}