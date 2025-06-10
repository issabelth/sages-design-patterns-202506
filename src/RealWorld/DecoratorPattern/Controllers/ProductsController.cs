using DecoratorPattern.Abstractions;
using DecoratorPattern.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var product = await productService.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}
