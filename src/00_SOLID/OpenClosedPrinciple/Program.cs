// Zasada otwarte – zamknięte (Open/Closed Principle) - OCP

// Każda klasa powinna być otwarta na rozbudowę ale zamknięta na modyfikacje.
// Oznacza to, że taka klasa pozwala na rozszerzenie swojego zachowania
// bez modyfikowania kodu źródłowego.


var discountsA = new Dictionary<string, decimal>
{
    ["Regular"] = 0.9m,
    ["Premium"] = 0.8m,
    ["VIP"] = 0.5m,
};

var discountsB = new Dictionary<string, decimal>
{
    ["Regular"] = 0.7m,
    ["Premium"] = 0.6m,
    ["VIP"] = 0.4m,
};

DiscountCalculator calculator = new DiscountCalculator(discountsA);

var discount = calculator.CalculateDiscount("Regular", 10);

Console.WriteLine(discount);


// Dobre podejście – otwarte na rozszerzenie a zamknięci na modyfikację ("działa? - nie tykaj!")
public class DiscountCalculator
{
    private IDictionary<string, decimal> discounts;

    public DiscountCalculator(IDictionary<string, decimal> discounts)
    {
        this.discounts = discounts;
    }

    public decimal CalculateDiscount(string customerType, decimal total)
    {
        return total * discounts[customerType];
    }
}

