// Zasada odwracania zależności (DIP – Dependency Inversion Principle)
// Wszystkie zależności powinny w jak największym stopniu zależeć od abstrakcji a nie od konkretnego typu.
// Oznacza to, że w kodzie powinny być używane interfejsy lub klasy abstrakcyjne, zamiast bezpośrednio operować na konkretnych klasach.


using System.Net.Security;

IMessageSender sender = new ColorConsoleSender();

NotificationService notificationService = new NotificationService(sender);
notificationService.Notify("Hello world!");

public class EmailSender : IMessageSender
{
    public void Send(string message) => Console.WriteLine($"Sending email: {message}");
}

public class ColorConsoleSender : IMessageSender
{
    public void Send(string message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
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

// to samo co wyżej, tylko nie trzeba pisać konstruktora i przypisywać wartości ręcznie
public class NotificationServiceOld
{
    /*
     * Można konstrukor i w niego wstrzykiwać już new EmailSender, ale nadal trzeba konkretnie EmailSender
     */
    private IMessageSender _sender;

    public NotificationServiceOld(IMessageSender sender)
    {
        _sender = sender;
    }

    public void Notify(string msg) => _sender.Send(msg);
}