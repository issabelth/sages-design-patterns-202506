using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethodTemplate.UnitTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void Render_RazorViewEngine_ShouldReturnsRenderedByRazor()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            var result = controller.GetProducts();

            // Assert
            Assert.AreEqual("View rendered by Razor", result);

        }
    }
}
