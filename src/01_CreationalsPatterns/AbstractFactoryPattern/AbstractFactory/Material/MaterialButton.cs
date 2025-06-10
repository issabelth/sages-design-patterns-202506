using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory.Material
{
    public class MaterialButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Material Button");
        }
    }
}
