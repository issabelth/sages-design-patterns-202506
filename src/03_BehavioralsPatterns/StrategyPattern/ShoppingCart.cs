using System;

namespace StrategyPattern;

public class ShoppingCart
{
    private double _price;
    private readonly TimeSpan from;
    private readonly TimeSpan to;
    private readonly DateTime specialDate;

    public DateTime OrderDate { get; set; }

    public ShoppingCart(double price, TimeSpan from, TimeSpan to, DateTime specialDate)
    {
        _price = price;
        this.from = from;
        this.to = to;
        this.specialDate = specialDate;
    }

    // Obliczanie ceny na podstawie zniżki
    public double CalculateTotalPrice()
    {
        // Happy Hours
        if (OrderDate.TimeOfDay >= from && OrderDate.TimeOfDay <= to)
        {
            return _price * 0.90; // 10% zniżki
        }
        // Black Friday
        else if (OrderDate == specialDate)
        {
            return _price * 0.80; // 20% zniżki
        }
        else
        {
            // No Discount
            return _price; // Brak zniżki
        }
    }
}