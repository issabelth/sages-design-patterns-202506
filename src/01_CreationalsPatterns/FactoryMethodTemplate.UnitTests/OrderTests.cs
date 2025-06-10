using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethodTemplate.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void DiscountedAmount_RegularDiscount_ShouldReturnsDiscount()
        {
            // Arrange
            Order order = new Order(1000, 0.1m);

            // Act
            var result = order.DiscountedAmount;

            // Assert
            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void DiscountedAmount_IrregularDiscount_ShouldReturnsDiscount()
        {
            // Arrange
            Order order = new Order(1000, 0.15m);

            // Act
            var result = order.DiscountedAmount;

            // Assert
            Assert.AreEqual(850, result);
        }
    }
}
