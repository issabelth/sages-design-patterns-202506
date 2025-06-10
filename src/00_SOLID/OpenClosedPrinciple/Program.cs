// Zasada otwarte – zamknięte (Open/Closed Principle) - OCP

// Każda klasa powinna być otwarta na rozbudowę ale zamknięta na modyfikacje.
// Oznacza to, że taka klasa pozwala na rozszerzenie swojego zachowania
// bez modyfikowania kodu źródłowego.



DiscountCalculator calculator = new DiscountCalculator();

var discount = calculator.CalculateDiscount("Regular", 10);


// Złe podejście – każda nowa zniżka wymaga modyfikacji:
public class DiscountCalculator
{
    public decimal CalculateDiscount(string customerType, decimal total)
    {
        if (customerType == "Regular") return total * 0.9m;
        if (customerType == "Premium") return total * 0.8m;
        return total;
    }
}