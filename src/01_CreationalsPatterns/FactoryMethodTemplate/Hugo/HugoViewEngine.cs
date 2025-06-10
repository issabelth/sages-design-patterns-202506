using FactoryMethodTemplate.Razor;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Hugo
{
    public class HugoViewEngine : IViewEngine
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            return "View rendered by Hugo";
        }
    }
}
