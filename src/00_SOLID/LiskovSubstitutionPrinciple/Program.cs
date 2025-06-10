// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// Zasada Liskov mówi o tym, że obiekt klasy pochodnej może być używany zamiennie
// w miejscu obiektu klasy bazowej, nie wprowadzając nieoczekiwanych zachowań.

// Przykład łamiący zasadę podstawiania Liskov

using System.Runtime.InteropServices;

Document doc1 = new PDFDocument();
Document doc2 = new TextDocument();
Document doc3 = new XmlDocument();

/*
 * 3.
 * Dodajemy IF
 */
if (doc1 is IPrintable printable)
{
    printable.Print();
}
if (doc1 is IEditable editable)
{
    editable.Edit();
}
if (doc1 is IEncryptable encryctable)
{
    encryctable.Encrypt();
}

// generyczność nic nie da, bo bazowo w pdf ma nie być edycji
//((TextDocument)doc2).Edit();  // <-- to łamie zasadę, bo kod kliencki uzależnia się od konkretnego typu.

/*
 * 1. Dodajemy interfejsy
 */
interface IPrintable
{
    void Print();
}
interface IEditable
{
    void Edit();
}
interface IEncryptable
{
    void Encrypt();
}

abstract class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }
}

class PDFDocument : Document, IPrintable, IEncryptable
{
    public override void Print()
    {
        Console.WriteLine("Printing a PDF document...");
    }

    public void Encrypt()
    {
        Console.WriteLine("Encrypting a PDF document...");
    }
}

class TextDocument : Document, IPrintable, IEditable
{
    public override void Print()
    {
        Console.WriteLine("Printing a text document...");
    }

    public void Edit()
    {
        Console.WriteLine("Editing a text document...");
    }
}

class XmlDocument : Document, IPrintable, IEncryptable
{
    public override void Print()
    {
        Console.WriteLine("Printing an XML document...");
    }

    public void Encrypt()
    {
        Console.WriteLine("Encrypting an XML document...");
    }
}

// ------------------------------------------------------------------------------------------------------------

/* Kiedy nie stosować interface?
 * Jak jest 1:1 i nie ma to sensu. Można np. jak imię i nazwisko ma interfejs IPerson i jest Person i Customer,
 * które dziedziczą po IPerson i mają woje doadtkowe pola.
 */

interface ICustomer
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
}

class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}