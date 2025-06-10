// Zasada odwracania zależności (DIP – Dependency Inversion Principle)
// Wszystkie zależności powinny w jak największym stopniu zależeć od abstrakcji a nie od konkretnego typu.
// Oznacza to, że w kodzie powinny być używane interfejsy lub klasy abstrakcyjne, zamiast bezpośrednio operować na konkretnych klasach.


IMessageSender sender = new ColorConsoleSender();

NotificationService notificationService = new NotificationService(sender);
notificationService.Notify("Hello, World!");


//  Dobre podejście – nie zależymy od konkretnej implementacji:
public class EmailSender : IMessageSender
{
    public void Send(string message) => Console.WriteLine($"Sending email: {message}");
}

public class ColorConsoleSender : IMessageSender
{
    public void Send(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Sending console: {message}");
        Console.ResetColor();
    }
}

public interface IMessageSender
{
    void Send(string message);
}


public class NotificationService(IMessageSender sender) // Primary Constructor
{ 
     public void Notify(string msg) => sender.Send(msg);
}