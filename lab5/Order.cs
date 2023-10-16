namespace lab5;
public class Order
{
    public List<Product> Products { get; set; }
    public List<int> Quantities { get; set; }
    public double TotalPrice => CalculateTotalPrice();
    public string Status { get; set; }

    public List<string> ProductNames => GetProductNames();

    private double CalculateTotalPrice()
    {
        double total = 0;
        for (int i = 0; i < Products.Count; i++)
        {
            total += Products[i].Price * Quantities[i];
        }
        return total;
    }

    private List<string> GetProductNames()
    {
        var names = new List<string>();
        for (int i = 0; i < Products.Count; i++)
        {
            names.Add(Products[i].Name);
        }
        return names;
    }
}



