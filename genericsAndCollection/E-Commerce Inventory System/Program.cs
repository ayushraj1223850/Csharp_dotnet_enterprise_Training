using System;
using System.Collections.Generic;
using System.Linq;

#region Interfaces & Enums

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category
{
    Electronics,
    Clothing,
    Books,
    Groceries
}

#endregion

#region Repository

public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (_products.Any(p => p.Id == product.Id))
            throw new Exception("Product ID must be unique");

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new Exception("Product name cannot be empty");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        _products.Add(product);
    }

    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }

    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll() => _products;
}

#endregion

#region Products

public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;

    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

#endregion

#region Discount Wrapper

public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new Exception("Discount must be between 0–100");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | After { _discountPercentage }%: {DiscountedPrice}";
    }
}

#endregion

#region Inventory Manager

public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\n--- All Products ---");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        var mostExpensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        if (mostExpensive != null)
            Console.WriteLine($"\nMost Expensive: {mostExpensive.Name}");

        Console.WriteLine("\n--- Grouped By Category ---");
        var grouped = products.GroupBy(p => p.Category);
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group)
                Console.WriteLine("  " + p.Name);
        }

        Console.WriteLine("\n--- 10% Discount on Electronics > ₹500 ---");
        foreach (var p in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            var discounted = new DiscountedProduct<T>(p, 10);
            Console.WriteLine(discounted);
        }
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        foreach (var product in products)
        {
            decimal newPrice = priceAdjuster(product);
            if (newPrice <= 0)
                throw new Exception("Invalid updated price");

            typeof(T).GetProperty("Price")?.SetValue(product, newPrice);
        }
    }
}

#endregion

#region Main Program

class Program
{
    static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        // Adding Products
        repo.AddProduct(new ElectronicProduct
        {
            Id = 1,
            Name = "Laptop",
            Price = 800,
            Brand = "Dell",
            WarrantyMonths = 24
        });

        repo.AddProduct(new ElectronicProduct
        {
            Id = 2,
            Name = "Mobile",
            Price = 600,
            Brand = "Samsung",
            WarrantyMonths = 12
        });

        repo.AddProduct(new ElectronicProduct
        {
            Id = 3,
            Name = "Headphones",
            Price = 150,
            Brand = "Sony",
            WarrantyMonths = 6
        });

        repo.AddProduct(new ElectronicProduct
        {
            Id = 4,
            Name = "Smart TV",
            Price = 1200,
            Brand = "LG",
            WarrantyMonths = 36
        });

        repo.AddProduct(new ElectronicProduct
        {
            Id = 5,
            Name = "Camera",
            Price = 950,
            Brand = "Canon",
            WarrantyMonths = 18
        });

        // Find by Brand
        Console.WriteLine("\n--- Sony Products ---");
        var sonyProducts = repo.FindProducts(p => p.Brand == "Sony");
        foreach (var p in sonyProducts)
            Console.WriteLine(p.Name);

        Console.WriteLine($"\nTotal Inventory Value: ₹{repo.CalculateTotalValue()}");

        var manager = new InventoryManager();
        manager.ProcessProducts(repo.GetAll());

        // Bulk Price Update (+50)
        manager.UpdatePrices(repo.GetAll(), p => p.Price + 50);

        Console.WriteLine("\n--- After Price Update ---");
        foreach (var p in repo.GetAll())
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
    }
}

#endregion
