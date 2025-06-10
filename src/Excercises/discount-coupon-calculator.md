## Ćwiczenie - Kalkulator rabatów

## Opis

Sklep internetowy przygotowuje się do uruchomienia promocji. Każdy kupujący będzie mógł skorzystać z okazji, wprowadzając **kod kuponu** podczas procesu zamawiania. Kody są wielorazowe (stałe) lub jednorazowe (z puli wygenerowanych kodów). System powinien automatycznie przeliczyć cenę na podstawie udzielonego rabatu.

## Zadanie

Utwórz kalkulator _DiscountCalculator_ z metodą _CalculateDiscount(decimal price, string discountCode)_ do obliczania ceny na podstawie kodu kuponu według poniższych wymagań.


## Wymagania funkcjonalne

1. **Pusty kod kuponu** - W przypadku podania pustego kodu rabat nie będzie udzielany.
2. **Rabat 10%** - Kupon z kodem `SAVE10NOW` udziela rabatu 10%.
3. **Rabat 20%** - Kupon z kodem `DISCOUNT20OFF` udziela rabatu 20%.
4. **Obsługa ujemnych cen** - Wywołanie metody `CalculateDiscount` z ujemną ceną powinno rzucać wyjątekm `ArgumentException` z komunikatem `"Negatives not allowed"`.
5. **Błędny kod kuponu** - W przypadku błędnego kodu powinien być zwracany wyjątek `ArgumentException` z komunikatem `"Invalid discount code"`.
6. **Rabat jednorazowy 50%** - Kupon z kodem, który jest częścią predefiniowanej puli kodów rabatowych, udziela jednorazowego rabatu 50%.

## Wymagania niefunkcjonalne
- Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):
  - **Red** - kod nieprzechodzący test
  - **Green** - kod przechodzący test
  - **Refactor** - refaktoryzacja kodu i testów
- Kod powinien być czytelny i łatwy do dalszego rozwoju
- Wskazówka: zastosuj wzorce projektowe

