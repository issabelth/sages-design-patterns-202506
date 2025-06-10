using System;

namespace BridgePattern;

public class TaxTransferBankPayment
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");

        Console.WriteLine($"Przelew podatkowy {amount}");
    }
}
