var shoppingCart = new ShoppingCart();
var paymentProcessor = new PaymentProcessor();
var emailNotifier = new EmailNotifier();

// Dodaj produkty do koszyka
shoppingCart.AddItem("Laptop", 1200.99m);
shoppingCart.AddItem("Mouse", 25.49m);

// Koszyk rozpoczyna proces płatności
shoppingCart.Checkout(paymentProcessor);

// Po przetworzeniu płatności wysyłamy potwierdzenie
emailNotifier.SendConfirmation("user@example.com");

// Czyścimy koszyk
shoppingCart.ClearCart();

public class ShoppingCart
{
    private readonly List<string> _items = new List<string>();
    private decimal _totalAmount = 0;

    public void AddItem(string item, decimal price)
    {
        _items.Add(item);
        _totalAmount += price;
        Console.WriteLine($"Item added: {item} - ${price:F2}");
    }

    public decimal GetTotalAmount() => _totalAmount;

    public void Checkout(PaymentProcessor paymentProcessor)
    {
        Console.WriteLine("ShoppingCart: Initiating checkout...");
        paymentProcessor.ProcessPayment(_totalAmount);
    }

    public void ClearCart()
    {
        _items.Clear();
        _totalAmount = 0;
        Console.WriteLine("ShoppingCart: Cart is now empty.");
    }
}


public class PaymentProcessor
{   
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"PaymentProcessor: Processing payment of ${amount:F2}...");
        // Symulacja przetwarzania płatności
        System.Threading.Thread.Sleep(1000); // Symulacja opóźnienia
        Console.WriteLine("PaymentProcessor: Payment processed successfully.");

    }
}

public class EmailNotifier
{
    public void SendConfirmation(string email)
    {
        Console.WriteLine($"EmailNotifier: Sending confirmation email to {email}...");
        // Symulacja wysyłania e-maila
        System.Threading.Thread.Sleep(500); // Symulacja opóźnienia
        Console.WriteLine($"EmailNotifier: Confirmation email sent to {email}.");
    }
}