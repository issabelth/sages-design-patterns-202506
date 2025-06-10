using System;

namespace BridgePattern;

public class HealthInsuranceTransferCreditCard
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą PIN");

        Console.WriteLine($"Przelew składki zdrowotnej {amount}");
    }
}
