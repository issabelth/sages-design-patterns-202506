using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    public class Controller
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            var engine = new RazorViewEngine(); // Problem
            var html = engine.Render(viewName, context);

            return html;
        }
    }
}
