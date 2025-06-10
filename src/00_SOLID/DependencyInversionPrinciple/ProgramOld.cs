// Zasada odwracania zależności (DIP – Dependency Inversion Principle)
// Wszystkie zależności powinny w jak największym stopniu zależeć od abstrakcji a nie od konkretnego typu.
// Oznacza to, że w kodzie powinny być używane interfejsy lub klasy abstrakcyjne, zamiast bezpośrednio operować na konkretnych klasach.

#if false

EmailSender sender = new EmailSender();
sender.Send("Hello, World!");

//  Złe podejście – zależność od konkretnej implementacji:
public class EmailSender
{
    public void Send(string message) => Console.WriteLine($"Sending email: {message}");
}

public class NotificationService
{
    private EmailSender _sender = new EmailSender();
    public void Notify(string msg) => _sender.Send(msg);
}

#endif