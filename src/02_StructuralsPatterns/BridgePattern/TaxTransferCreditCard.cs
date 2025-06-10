using System;

namespace BridgePattern;

public class TaxTransferCreditCard
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą PIN");

        Console.WriteLine($"Przelew podatkowy {amount}");
    }
}
