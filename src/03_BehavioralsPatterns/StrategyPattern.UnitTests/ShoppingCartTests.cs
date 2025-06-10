using System;
using Xunit;

namespace StrategyPattern.UnitTests;

public class ShoppingCartTests
{
    [Theory]
    [InlineData(100.0, "14:00", "16:00", "15:00", 90.0)] // Happy Hours
    [InlineData(200.0, "08:00", "10:00", "09:30", 180.0)] // Happy Hours
    public void CalculateTotalPrice_HappyHours_DiscountApplied(
        double price, string fromTime, string toTime, string orderTime, double expectedPrice)
    {
        // Arrange
        TimeSpan from = TimeSpan.Parse(fromTime);
        TimeSpan to = TimeSpan.Parse(toTime);
        DateTime specialDate = DateTime.Today; // Irrelevant for Happy Hours
        DateTime orderDate = DateTime.Today.Add(TimeSpan.Parse(orderTime));

        var cart = new ShoppingCart(price, from, to, specialDate)
        {
            OrderDate = orderDate
        };

        // Act
        double result = cart.CalculateTotalPrice();

        // Assert
        Assert.Equal(expectedPrice, result, 2); // Assert with precision
    }

    [Theory]
    [InlineData(100.0, "2023-11-24", "2023-11-24", 90.0)] // Black Friday
    [InlineData(150.0, "2023-12-25", "2023-12-25", 135.0)] // Black Friday
    public void CalculateTotalPrice_BlackFriday_DiscountApplied(
        double price, string specialDate, string orderDate, double expectedPrice)
    {
        // Arrange
        TimeSpan from = TimeSpan.Zero; // Irrelevant for Black Friday
        TimeSpan to = TimeSpan.Zero;   // Irrelevant for Black Friday
        DateTime blackFriday = DateTime.Parse(specialDate);
        DateTime order = DateTime.Parse(orderDate);

        var cart = new ShoppingCart(price, from, to, blackFriday)
        {
            OrderDate = order
        };

        // Act
        double result = cart.CalculateTotalPrice();

        // Assert
        Assert.Equal(expectedPrice, result, 2);
    }

    [Theory]
    [InlineData(100.0, "14:00", "16:00", "17:00", "2023-11-24", 100.0)] // No Discount
    [InlineData(200.0, "08:00", "10:00", "07:30", "2023-12-25", 200.0)] // No Discount
    public void CalculateTotalPrice_NoDiscount_FullPriceReturned(
        double price, string fromTime, string toTime, string orderTime, string specialDate, double expectedPrice)
    {
        // Arrange
        TimeSpan from = TimeSpan.Parse(fromTime);
        TimeSpan to = TimeSpan.Parse(toTime);
        DateTime blackFriday = DateTime.Parse(specialDate);
        DateTime order = DateTime.Today.Add(TimeSpan.Parse(orderTime));

        var cart = new ShoppingCart(price, from, to, blackFriday)
        {
            OrderDate = order
        };

        // Act
        double result = cart.CalculateTotalPrice();

        // Assert
        Assert.Equal(expectedPrice, result, 2);
    }
}