using System;

namespace AbstractFactoryPattern.AbstractFactory.Material
{
    public class MaterialTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Material TextBox");
        }
    }
}
