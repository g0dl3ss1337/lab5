namespace lab5;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Store : ISearchable
{

    public List<Product> Products { get; set; } = new List<Product>();
    public List<User> Users { get; set; } = new List<User>();
    public List<Order> Orders { get; set; } = new List<Order>();

    public List<Product> SearchByPrice(double minPrice, double maxPrice)
    {
        return Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
    }

    public List<Product> SearchByCategory(string category)
    {
        return Products.Where(p => p.Category == category).ToList();
    }

    public List<Product> SearchByRating(double minRating)
    {
        return Products.Where(p => p.Rating >= minRating).ToList();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void PlaceOrder(User user, List<Product> products, List<int> quantities)
    {
        if (products.Count != quantities.Count)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Помилка: Недостатня кількість товару.");
            return;
        }

        var order = new Order
        {
            Products = products,
            Quantities = quantities,
            Status = "В обробці."
        };

        Orders.Add(order);
        user.PurchaseHistory.Add(order);
    }

    public void DisplayProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Назва: {product.Name}");
            Console.WriteLine($"Ціна: {product.Price}$");
            Console.WriteLine($"Опис: {product.Description}");
            Console.WriteLine($"Категорія: {product.Category}");
            Console.WriteLine($"Оцінка: {product.Rating}");
            Console.WriteLine();
        }
    }

    public void DisplayOrderHistory(User user)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"Історія замовлень користувача {user.Username}:");
        foreach (var order in user.PurchaseHistory)
        {
            Console.WriteLine($"Статус замовлення: {order.Status}");
            Console.WriteLine("Замовлення:");

            for (int i = 0; i < order.ProductNames.Count; i++)
            {
                Console.WriteLine($"- {order.ProductNames[i]} (Кількість: {order.Quantities[i]})");
            }
            Console.WriteLine($"Повна сумма замовлення: {order.TotalPrice}$");
            Console.WriteLine();
        }
    }

    public Product FindProductByName(string name)
    {
        return Products.FirstOrDefault(p => p.Name == name);
    }

    public User FindUserByUsername(string username)
    {
        return Users.FirstOrDefault(u => u.Username == username);
    }
}



