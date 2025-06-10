# List kontrola urządzenia

## Opis
Celem jest stworzenie aplikacji, która umożliwia okresową kontrolę urządzeń zgodnie z przygotowaną checklistą. 
Aplikacja powinna przeprowadzać analizę, a wyniki prezentować w formie raportu zgodnego ze stanem urządzenia.



## Zadanie
Zaprojektuj i zaimplementuj mechanizm sprawdzający stan urządzeń na podstawie poniższych wymagań. Wynik analizy ma być zapisany w formie checklisty, która pokaże szczegółowe dane dotyczące procesu i stanu każdego urządzenia.

Poniższa klasa reprezentuje urządzenie:

```cs
public class Device
{
    public string Name { get; set; }

    public Device(string name)
    {
        Name = name;        
    }

	public override string ToString()
    {
        return $"Name: {Name}";
    }
}
```

## Wymagania funkcjonalne

- **1. Sprawdzenie, czy urządzenie jest czyste.:**
  - Ustal, czy urządzenie jest czyste.
  - Jeśli nie, wyczyść urządzenie i zaktualizuj status.

- **2. Sprawdzenie, czy urządzenie ma zasilanie.:**
  - Upewnij się, że urządzenie ma zasilanie.
  - Jeśli zasilanie nie działa, zakończ kontrolę dla tego urządzenia i oznacz wynik jako przerwany.

- **3. Sprawdzenie, czy urządzenie grzeje:**
  - Zweryfikuj, czy urządzenie jest w stanie generować ciepło.
  - W przypadku usterki zainicjuj naprawę systemu grzewczego.

4. Sprawdzanie ogólnej operacyjności
  - Ostatecznie sprawdź, czy urządzenie jest w pełni operacyjne.
  - Jeśli nie, zapisz działania naprawcze (np. konserwacja).

## Wymagania raportowe

- **Przypadek 1: Zasilanie nie działa**
Raport powinien prezentować przerwaną kontrolę ze szczegółowym wyjaśnieniem:

| **Etap**              | **Wynik**                                 |
|------------------------|-------------------------------------------|
| Sprawdzanie zasilania  | Urządzenie 'Device A' nie ma zasilania. Przerwano.  |


Syntetyczny stan urządzenia:

| **Stan**              | **Wynik**                                 |
|------------------------|-------------------------------------------|
| - Has Power            | False                                    |
| - Is Clean             | False                                    |
| - Is Heating           | False                                    |
| - Is Operational       | False                                    |


- **Przypadek 2: Pełny wynik przy działającym urządzeniu**
Raport z pełnej kontroli dla działającego urządzenia powinien zawierać szczegółowe informacje:

| **Etap**              | **Wynik**                                 |
|------------------------|-------------------------------------------|
| Sprawdzanie zasilania  | Urządzenie 'Device A' ma zasilanie.       |
| Sprawdzanie czystości  | Urządzenie 'Device A' jest brudne.        |
|                        | Czyszczenie...                           |
| Sprawdzanie grzania    | Urządzenie 'Device A' nie grzeje.         |
|                        | Naprawa systemu grzewczego...            |
| Sprawdzanie operacyjności | Urządzenie 'Device A' nie działa.         |
|                        | Wykonywanie konserwacji...               |

| **Stan**              | **Wynik**                                 |
|------------------------|-------------------------------------------|
| - Has Power            | False                                    |
| - Is Clean             | False                                    |
| - Is Heating           | False                                    |
| - Is Operational       | False                                    |

