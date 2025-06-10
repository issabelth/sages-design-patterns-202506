using DecoratorPattern.Abstractions;
using DecoratorPattern.Domain;

namespace DecoratorPattern.Infrastructures;

public class DbProductRepository
{
    private readonly IDictionary<int, Product> products;

    public DbProductRepository()
    {
        products = new Dictionary<int, Product>()
        {
            [1] = new Product(1, "Product 1", "Lorem ipsum"),
            [2] = new Product(2, "Product 2", "Lorem ipsum"),
            [3] = new Product(3, "Product 3", "Lorem ipsum"),
        };
    }

    public async Task<Product?> Get(int id)
    {
        // Simulating a error with 50% chance of success
        if (Random.Shared.Next(2) == 0)
            throw new Exception("Database error occured!");

        // Simulate delay
        await Task.Delay(100);

        if (products.TryGetValue(id, out Product? product))
        {
            return product;
        }
        else
            return null;
    }
}
