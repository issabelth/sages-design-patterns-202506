namespace SingletonPattern
{
    public class MessageService
    {
        public Logger logger;

        public MessageService()
        {
            logger = Logger.Instance;
        }

        public void Send(string message)
        {
            logger.LogInformation($"Send {message}");
        }
    }
}
