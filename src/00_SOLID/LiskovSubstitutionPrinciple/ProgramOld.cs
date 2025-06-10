// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// Zasada Liskov mówi o tym, że obiekt klasy pochodnej może być używany zamiennie
// w miejscu obiektu klasy bazowej, nie wprowadzając nieoczekiwanych zachowań.

// Przykład łamiący zasadę podstawiania Liskov

#if false

Document doc1 = new PDFDocument();
Document doc2 = new TextDocument();

doc1.Print();
((TextDocument)doc2).Edit();  // <-- to łamie zasadę, bo kod kliencki uzależnia się od konkretnego typu.

class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }
}

class PDFDocument : Document
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

class TextDocument : Document
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

#endif