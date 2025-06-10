# Rozszerz starą drukarkę

## Opis
Firma posiada funkcję do obsługi starej drukarki:

```cs
public class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}
``

Tego kodu nie może modyfikować.


Firma zakupiła nową drukarkę, która umożliwia drukowanie określonej ilości kopii oraz obliczanie kosztu wydruku:

```cs
public class Printer
{
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
    }

    private decimal CalculateCost(int copies)
    {
        // Calculate total cost based on the number of copies and cost per copy
        return copies * _costPerCopy;
    }
}
```

Chciałaby uzyskać taką samą funkcjonalność na starej drukarce.



## Zadanie

Twoim zadaniem jest stworzenie rozwiązania, które rozszerzy funkcjonalność starej drukarki tak, aby obsługiwała zarówno możliwość drukowania wielu kopii, jak i obliczania kosztu wydruku, bez modyfikowania istniejącej klasy `LegacyPrinter`.


## Wymagania
1. **Ilość kopii** - Należy dodać możliwość drukowania wielu kopii na starej drukarce. Wartość domyślna to 1 kopia, ale użytkownik powinien mieć możliwość określenia innej liczby kopii.
2. **Obliczanie kosztu wydruku** - Stara drukarka powinna obliczać koszt na podstawie liczby kopii, podobnie jak nowa drukarka.
3. **Zakaz modyfikowania starego kodu** - Klasa `LegacyPrinter` nie może być modyfikowana, ponieważ w przeciwnym razie firma straci gwarancję na sprzęt.