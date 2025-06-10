namespace SingletonPattern.XUnitTests
{

    public class LoggerTests
    {
        [Fact]
        public void Create_CallTwice_ShouldBeTheSameInstance()
        {
            // Arrange

            // Act
            MessageService messageService = new MessageService();
            PrintService printService = new PrintService();

            // Assert
            Assert.Same(messageService.logger, printService.logger);
        }
    }
}