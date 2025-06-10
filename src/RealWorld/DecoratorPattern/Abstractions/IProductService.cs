using DecoratorPattern.Domain;

namespace DecoratorPattern.Abstractions;

public interface IProductService
{
    Task<Product?> Get(int id);
}
