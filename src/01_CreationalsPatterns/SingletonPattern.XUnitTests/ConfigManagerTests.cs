namespace SingletonPattern.XUnitTests
{
    public class ConfigManagerTests
    {
        [Fact]
        public void SetGet_WhenCalled_ShouldReturnsValue()
        {
            // Arrange
            ConfigManager manager = new ConfigManager();
            manager.Set("name", "Marcin");

            ConfigManager other = new ConfigManager();

            // Act
            object result = other.Get("name");

            // Assert
            Assert.Equal("Marcin", result);

        }
    }
}