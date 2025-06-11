using FactoryMethodTemplate.Hugo;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    // Abstract
    public interface IViewEngine
    {
        string Render(string viewName, IDictionary<string, object> context);
    }

    public class Controller
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            var engine = Create(); 
            var html = engine.Render(viewName, context);

            return html;
        }

        protected virtual IViewEngine Create()
        {
            return new RazorViewEngine();
        }
    }

    public class HugoController : Controller
    {
        protected override IViewEngine Create()
        {
            return new HugoViewEngine();
        }
    }
}
