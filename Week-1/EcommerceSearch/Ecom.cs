using System;
using System.Collections.Generic;

class Program
{
    public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }
}

    static void Main()
    {
        List<Product> products = new List<Product>();

        Console.Write("How many products do you want to enter? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for product #{i + 1}");

            Console.Write("Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Product p = new Product(id, name, category);
            products.Add(p);
        }

        Console.WriteLine("\nList of Products:");
        foreach (Product p in products)
        {
            Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Category: {p.Category}");
        }

        // ========================
        // 🔍 Linear Search
        // ========================
        Console.Write("\nEnter product name to search (Linear Search): ");
        string linearSearchName = Console.ReadLine();

        Product linearResult = LinearSearch(products.ToArray(), linearSearchName);
        if (linearResult != null)
        {
            Console.WriteLine($"[Linear] Found: ID = {linearResult.ProductId}, Name = {linearResult.ProductName}");
        }
        else
        {
            Console.WriteLine("[Linear] Product not found.");
        }

        // ========================
        // 🔍 Binary Search
        // ========================
        Product[] productArray = products.ToArray();
        Array.Sort(productArray, (a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.Write("\nEnter product name to search (Binary Search): ");
        string binarySearchName = Console.ReadLine();

        Product binaryResult = BinarySearch(productArray, binarySearchName);
        if (binaryResult != null)
        {
            Console.WriteLine($"[Binary] Found: ID = {binaryResult.ProductId}, Name = {binaryResult.ProductName}");
        }
        else
        {
            Console.WriteLine("[Binary] Product not found.");
        }
    }

    // ========== Linear Search ==========
    static Product LinearSearch(Product[] products, string name)
    {
        foreach (var p in products)
        {
            if (p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    // ========== Binary Search ==========
    static Product BinarySearch(Product[] products, string name)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int compare = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (compare == 0)
                return products[mid];
            else if (compare < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }
}
