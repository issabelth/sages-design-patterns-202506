using System;

namespace BridgePattern;

public class HealthInsuranceTransferBlik
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

        Console.WriteLine($"Przelew składki zdrowotnej {amount}");
    }
}
