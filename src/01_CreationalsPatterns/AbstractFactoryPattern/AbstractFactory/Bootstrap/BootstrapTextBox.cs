using System;

namespace AbstractFactoryPattern.AbstractFactory.Bootstrap
{
    public class BootstrapTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Bootstrap TextBox");
        }
    }
}
