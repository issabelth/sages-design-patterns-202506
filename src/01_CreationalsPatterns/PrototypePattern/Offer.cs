using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern;

public class Offer
{
    public string OfferNumber { get; set; } = default!;
    public string Product { get; set; } = default!;
    public decimal BasePrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime ValidUntil { get; set; }

    public decimal GetFinalPrice() => BasePrice * (1 - DiscountPercent / 100);

    public override string ToString() =>
        $"{OfferNumber}: {Product} ({BasePrice:C} - {DiscountPercent}% = {GetFinalPrice():C}), valid until {ValidUntil:d}";
}
