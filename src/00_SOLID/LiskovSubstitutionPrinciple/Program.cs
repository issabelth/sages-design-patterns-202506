// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// Zasada Liskov mówi o tym, że obiekt klasy pochodnej może być używany zamiennie
// w miejscu obiektu klasy bazowej, nie wprowadzając nieoczekiwanych zachowań.

Document doc1 = new PDFDocument();
Document doc2 = new TextDocument();
Document doc3 = new XmlDocument();

Document doc = doc2;

if (doc is IPrintable printable)
{
    printable.Print();
}


if (doc is IEditable editable)
{
    editable.Edit();
}

if (doc is IEncryptable encryptable)
{
    encryptable.Encrypt();
    encryptable.Decrypt();
}
    
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
    void Decrypt();
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

    public void Decrypt()
    {
        Console.WriteLine("Decrypting a PDF document...");
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
        Console.WriteLine("Editing a document...");
    }


}

class XmlDocument : Document, IPrintable, IEncryptable
{
    public void Encrypt()
    {
        Console.WriteLine("Encrypt xml");
    }

    public override void Print()
    {
        Console.WriteLine("Printing a xml document...");
    }

    public void Decrypt()
    {
        Console.WriteLine("Decrypting a xml document...");
    }


}