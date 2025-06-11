using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrototypePattern.UnitTests;

public class OfferTests
{
    [Fact]
    public void ManualCopy_ShouldCreateIndependentOfferButIsErrorProne()
    {
        // Arrange — szablon oferty
        var template = new Offer
        {
            OfferNumber = "TEMPLATE",
            Product = "5 Gallon Water",
            BasePrice = 25.00m,
            DiscountPercent = 10,
            ValidUntil = DateTime.Today.AddDays(14)
        };

        // Act — kopiowanie ręczne (ktoś zapomniał o polu DiscountPercent!)
        var copied = new Offer
        {
            Product = template.Product,
            BasePrice = template.BasePrice,
            ValidUntil = template.ValidUntil,
            OfferNumber = "OFFER-001",
        };

        // Assert — pole DiscountPercent NIE zostało skopiowane (ma wartość domyślną 0)
        Assert.NotEqual(template.DiscountPercent, copied.DiscountPercent); // ❌ test przechodzi, ale pokazuje błąd projektowy
        Assert.Equal(22.5m, template.GetFinalPrice()); // 25 - 10%
        Assert.Equal(25.0m, copied.GetFinalPrice());   // brak rabatu
    }
}
