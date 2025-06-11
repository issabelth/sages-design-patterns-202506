using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern;

interface ILogger
{
    void Info(string message);
}

internal class Printer
{
    public Action<string> Log { get; set; }    // Zmienna, która przechowuje listę funkcji typu void (string)

    public void Print(string content, int copies = 1)
    {
        string message = $"[{DateTime.UtcNow}] content: {content} copies: {copies}";

        Log?.Invoke(message);

        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine($"Printing {content}... copy #{i}");
        }
    }
}
