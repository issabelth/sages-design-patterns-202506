using System;

namespace BridgePattern;

public class StandardTransferCreditCard
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą PIN");

        Console.WriteLine($"Przelew standardowy {amount}");
    }
}
