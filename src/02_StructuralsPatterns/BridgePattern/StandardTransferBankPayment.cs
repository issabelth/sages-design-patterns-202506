using System;

namespace BridgePattern;

public class StandardTransferBankPayment
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą login i hasła.");

        Console.WriteLine($"Przelew standardowy {amount}");

    }
}
