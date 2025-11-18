using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double productTotal = 0;

        foreach (Product p in _products)
        {
            productTotal += p.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5 : 35;

        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL:");

        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
        }

        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("SHIPPING LABEL:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}
