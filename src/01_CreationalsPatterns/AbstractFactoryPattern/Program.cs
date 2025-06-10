using AbstractFactoryPattern.AbstractFactory.App;
using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Abstract Factory Method Pattern!");

            ContactForm form = new ContactForm();
            form.Render(Theme.Material);

        }
    }
}
