# Kalkulator kuponów rabatowych

## Opis
Sklep internetowy przygotowuje się do uruchomienia promocji. Każdy kupujący będzie mógł skorzystać z okazji, wprowadzając kod kuponu podczas procesu zamawiania. Kupony rabatowe będą stałe lub jednorazowe.

## Zadanie

Utwórz klasę `DiscountCalculator` z metodą `CalculateDiscount(decimal price, string discountCode)`, która będzie obliczać cenę na podstawie kodu kuponu, spełniając poniższe wymagania.

## Wymagania

1. **Pusty kod kuponu** - W przypadku podania pustego kodu rabat nie będzie udzielany.
2. **Rabat 10%** - Kupon z kodem `SAVE10NOW` udziela rabatu 10%.
3. **Rabat 20%** - Kupon z kodem `DISCOUNT20OFF` udziela rabatu 20%.
4. **Obsługa ujemnych cen** - Wywołanie metody `CalculateDiscount` z ujemną ceną powinno rzucać wyjątekm `ArgumentException` z komunikatem `"Negatives not allowed"`.
5. **Błędny kod kuponu** - W przypadku błędnego kodu powinien być zwracany wyjątek `ArgumentException` z komunikatem `"Invalid discount code"`.
6. **Rabat jednorazowy 50%** - Kupon z kodem, który jest częścią predefiniowanej puli kodów rabatowych, udziela jednorazowego rabatu 50%.

