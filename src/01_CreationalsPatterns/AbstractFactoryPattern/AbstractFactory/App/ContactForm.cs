using AbstractFactoryPattern.AbstractFactory.Bootstrap;
using AbstractFactoryPattern.AbstractFactory.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory.App
{
    public class ContactForm
    {
        public void Render(Theme theme)
        {
            if (theme == Theme.Material) {
                new MaterialTextBox().Render();
                new MaterialButton().Render();
            }
            else if (theme == Theme.Bootstrap)
            {
                new BootstrapTextBox().Render();
                new BootstrapButton().Render();
            }
        }
    }

    public enum Theme
    {
        Material,
        Bootstrap
    }
}
