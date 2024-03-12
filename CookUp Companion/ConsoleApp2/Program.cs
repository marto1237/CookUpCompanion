using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public string Aisle { get; set; }
    public string PossibleUnits { get; set; }
    public string Intolerances { get; set; }
}

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    
}

class Program
{
    static async Task Main(string[] args)
    {
        List<string> products = new List<string> { "salt", "olive oil", "butter", "sugar" };

        foreach (var productName in products)
        {
            Product product = await GetProductInfo(productName);
            if (product != null)
                Console.WriteLine($"Product '{product.Name}' retrieved successfully.");
            else
                Console.WriteLine($"Failed to retrieve product information for '{productName}'.");
        }
    }

    static async Task<Product> GetProductInfo(string productName)
    {
        string apiKey = "9f5b905af59f40b9840e6f89c57f1760";
        string baseUrl = "https://api.spoonacular.com/food/ingredients/autocomplete";

        string url = $"{baseUrl}?apiKey={apiKey}&query={productName}&number=1&metaInformation=true";

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Product>>(json);

                if (result.Count > 0)
                    return result[0];
            }
        }

        return null;
    }
}
