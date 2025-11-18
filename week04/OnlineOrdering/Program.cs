using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Duff Beer Pack", "DB001", 12.99, 3));
        order1.AddProduct(new Product("Donut Box", "DN777", 7.50, 2));

        Address address2 = new Address("221B Baker Street", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Sherlock Holmes", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Magnifying Glass", "MG555", 14.25, 1));
        order2.AddProduct(new Product("Detective Notebook", "DN900", 6.99, 4));

        Address address3 = new Address("1600 Pennsylvania Ave", "Washington", "DC", "USA");
        Customer customer3 = new Customer("Joe President", address3);
        Order order3 = new Order(customer3);

        order3.AddProduct(new Product("American Flag Set", "AF100", 29.99, 1));
        order3.AddProduct(new Product("Eagle Statue", "ES440", 54.90, 1));

        Address address4 = new Address("Av. Paulista 1578", "São Paulo", "SP", "Brazil");
        Customer customer4 = new Customer("Carlos Oliveira", address4);
        Order order4 = new Order(customer4);

        order4.AddProduct(new Product("Futebol Jersey", "FJ202", 35.80, 2));
        order4.AddProduct(new Product("Mate Tea Pack", "MT300", 8.60, 5));
        order4.AddProduct(new Product("Wireless Headphones", "WH450", 59.99, 1));

        Address address5 = new Address("Eloy Espinoza 701", "Lima", "Lima", "Peru");
        Customer customer5 = new Customer("Gabriela Huayta", address5);
        Order order5 = new Order(customer5);

        order5.AddProduct(new Product("Instant Ramen Box", "IR888", 24.99, 2));
        order5.AddProduct(new Product("Anime Figure", "AF009", 42.50, 1));

        DisplayOrder(1, order1);
        DisplayOrder(2, order2);
        DisplayOrder(3, order3);
        DisplayOrder(4, order4);
        DisplayOrder(5, order5);
    }

    static void DisplayOrder(int orderNumber, Order order)
    {
        Console.WriteLine($"===== ORDER {orderNumber} =====");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
        Console.WriteLine("-------------------------------------------");
    }
}
