using System;

namespace BridgePattern;

public class TaxTransferBlik
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

        Console.WriteLine($"Przelew podatkowy {amount}");
    }
}
