namespace lab5;

using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;


public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Store store = new Store();

        Product product1 = new Product
        {
            Name = "iPhone 15 Pro Max",
            Price = 1499.99,
            Description = "Останій iPhone",
            Category = "Електроніка",
            Rating = 4.8
        };

        Product product2 = new Product
        {
            Name = "Ноутбук",
            Price = 999.99,
            Description = "Потужний ноутбук для праці,навчання та ігор.",
            Category = "Електроніка",
            Rating = 4.3
        };

        Product product3 = new Product
        {
            Name = "Шапка",
            Price = 14.99,
            Description = "Тепла шапка на зиму.",
            Category = "Одяг",
            Rating = 4.9
        };

        Product product4 = new Product
        {
            Name = "Шкарпетки",
            Price = 4.99,
            Description = "Шкарпетки завжди потрібні.",
            Category = "Одяг",
            Rating = 5
        };

        User user1 = new User
        {
            Username = "g0dl3ss1337",
            Password = "oHa71!jj@s88!"
        };

        User user2 = new User
        {
            Username = "user2",
            Password = "l8n!ms19!"
        };

        List<Product> products = new List<Product> { product1, product2, product3, product4 };
        List<int> quantities = new List<int> { 20, 15, 5, 10 };

        store.AddProduct(product1);
        store.AddProduct(product2);
        store.AddProduct(product3);
        store.AddProduct(product4);
        store.AddUser(user1);
        store.AddUser(user2);

        // Створення замовлення для користувачів
        var newOrder1 = new Order
        {
            Products = new List<Product> { product1, product4 },
            Quantities = new List<int> { 1, 10 },
            Status = "Отримано."
        };

        user1.PurchaseHistory.Add(newOrder1);

        var newOrder2 = new Order
        {
            Products = new List<Product> { product2, product3 },
            Quantities = new List<int> { 1, 3 },
            Status = "Отримано."
        };

        user2.PurchaseHistory.Add(newOrder2);


        // Виведення товарів за допомогою пошуку
        var category1 = "Електроніка";
        var findresult1 = store.SearchByCategory(category1);
        Console.WriteLine($"Пошук продуктів за категорією [ {category1} ]\n");
        store.DisplayProducts(findresult1);

        var category2 = "Одяг";
        var findresult2 = store.SearchByCategory(category2);
        Console.WriteLine($"Пошук продуктів за категорією [ {category2} ]\n");
        store.DisplayProducts(findresult2);

        // Виведення користувачів та їх історії покупок
        store.DisplayOrderHistory(user1);
        store.DisplayOrderHistory(user2);
    }
}
