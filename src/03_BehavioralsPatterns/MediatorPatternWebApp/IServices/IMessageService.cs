namespace MediatorPatternWebApp.IServices
{
    public interface IMessageService
    {
        void Send(string recipient, string message);
    }
}
