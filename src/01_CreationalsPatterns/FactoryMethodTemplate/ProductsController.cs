using System.Collections.Generic;
using FactoryMethodTemplate.Razor;

namespace FactoryMethodTemplate
{
    public class ProductsController : Controller
    {
        public string GetProducts()
        {
            // Get products from database
            IDictionary<string, object> context = new Dictionary<string, object>();
            // context.Add(product);
            // context.Add(product);
            // context.Add(product);

            var html = Render("products.html", context);

            return html;
        }
    }
}
