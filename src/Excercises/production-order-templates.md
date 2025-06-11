# Szablony zleceń produkcyjnych

## Opis
Twoja firma realizuje zlecenia produkcyjne w trzech typach:
- Gięcie blachy
- Cięcie laserowe
- Malowanie proszkowe 

Zlecenia często mają powtarzające się parametry, dlatego planowane jest wprowadzenie szablonów, na podstawie których pracownicy mogą szybko generować nowe zlecenia.

## Zadanie

Twoim zadaniem jest przygotować system, który umożliwi:


## Wymagania funkcjonalne
1. Utworzenie szablonów zleceń każdego z trzech typów.
2. Wygenerowanie nowego zlecenia na podstawie istniejącego szablonu.
3. Modyfikację wygenerowanego zlecenia (bez wpływu na szablon!).
4. Obliczanie:
   - szacowanego czasu realizacji (EstimateTime()),
   - kosztu wykonania (CalculateCost()).


## Typy zleceń i ich właściwości
1. Gięcie blachy (BendingOrder)
```cs
string Material;    // np. "Steel", "Aluminum"
double Thickness;   // w mm
int Bends;          // liczba gięć
```

2. Cięcie laserowe (LaserCuttingOrder)
```cs
string Material;
double Length;      // w mm
bool HighPrecision; // precyzyjne cięcie
```

3. Malowanie proszkowe (PowderPaintingOrder)
```cs
string Color;       // np. "RAL 9005"
double Area;        // powierzchnia w m²
bool HasPrimer;     // czy z podkładem?
```


## Przykładowy scenariusz użycia
1. Użytkownik tworzy szablon `bending:steel` z domyślnymi parametrami.
2. Użytkownik tworzy nowe zlecenie na bazie tego szablonu.
3. Użytkownik modyfikuje tylko pole `Bends`, pozostawiając resztę bez zmian.
4. System wylicza czas i koszt produkcji.

## Przykład użycia (symulacja)
```cs
var template = new BendingOrder
{
    Material = "Steel",
    Thickness = 2.0,
    Bends = 3
};

// TODO: stwórz kopię zlecenia na podstawie szablonu
var order = ???;

order.Bends = 5;

Console.WriteLine(order.CalculateCost());
Console.WriteLine(order.EstimateTime());
```


## Przykładowy wynik działania
```
Order1: bending, Cost: 10.00 zł, Time: 0.5 h
Order2: powder-painting, Cost: 62.50 zł, Time: 1.5 h
```