using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodTemplate.Razor
{
    public class RazorViewEngine
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            return "View rendered by Razor";
        }
    }
}
