using System;

namespace BridgePattern;

public class StandardTransferBlik
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

        Console.WriteLine($"Przelew standardowy {amount}");
    }

}
