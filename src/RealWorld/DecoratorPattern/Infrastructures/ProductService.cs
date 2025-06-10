using DecoratorPattern.Abstractions;
using DecoratorPattern.Domain;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace DecoratorPattern.Infrastructures;

public class ProductService : IProductService
{
    private readonly DbProductRepository _repository;
    private readonly IMemoryCache _cache;

    public ProductService(DbProductRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<Product?> Get(int id)
    {
        // 1. Logging
        Console.WriteLine($"Get product by id: {id}");

        // 2. Caching
        if (_cache.TryGetValue(id, out Product? product))
        {
            return product;
        }

        IAsyncPolicy retryProlicy = Policy.Handle<Exception>()
            .RetryAsync(3, (exception, retryCount) => Console.WriteLine($"Retrying... Attempt #{retryCount}"));

        product = await retryProlicy.ExecuteAsync(async () => product = await _repository.Get(id));        

        _cache.Set(id, product, TimeSpan.FromMinutes(5));

        return product;

    }
}
