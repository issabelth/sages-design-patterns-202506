using System;

namespace BridgePattern;

public class HealthInsuranceTransferBankPayment
{
    public void MakeTransfer(decimal amount)
    {
        Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");

        Console.WriteLine($"Przelew składki zdrowotnej {amount}");
    }
}
