using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PrototypePattern.UnitTests
{
    // PM> Install-Package FluentAssertions

    [TestClass]
    public class InvoiceServiceTests
    {
        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeTheSameHeader()
        {
            // Arrange
            Customer customer = new Customer("John", "Smith");
            Invoice invoice = new Invoice("FA 1", DateTime.Parse("2022-03-01"), customer);
            
            invoice.Paid(700);

            // Act
            Invoice invoiceCopy = new Invoice(invoice.Number, invoice.CreateDate, invoice.Customer);

            // Assert
            invoiceCopy.Should().NotBeSameAs(invoice);

            invoiceCopy.Number.Should().Be("FA 1");
            invoiceCopy.CreateDate.Should().Be(DateTime.Parse("2022-03-01"));
            invoiceCopy.PaymentStatus.Should().Be(PaymentStatus.Paid);
            
        }

        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeTheSameCustomer()
        {
            // Arrange
            Customer customer = new Customer("John", "Smith");
            Invoice invoice = new Invoice("FA 1", DateTime.Parse("2022-03-01"), customer);
            invoice.Paid(700);

            // Act
            Invoice invoiceCopy = new Invoice(invoice.Number, DateTime.Today, invoice.Customer);

            // Assert
            invoiceCopy.Customer.Should().BeSameAs(invoice.Customer);

            


        }

        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeCopyOfDetails()
        {
            // Arrange
            Invoice invoice = CreateInvoice();
            invoice.Paid(700);

            // Act
            Invoice invoiceCopy = new Invoice(invoice.Number, DateTime.Today, invoice.Customer);

            // Assert
            
            var detailsReferenceEquals = invoice.Details.Zip(invoiceCopy.Details, (original, copy) => ReferenceEquals(original, copy));

            
            detailsReferenceEquals.All(x => x).Should().BeFalse();
            

        }

        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeTheSameProducts()
        {
            // Arrange
            Invoice invoice = CreateInvoice();
            invoice.Paid(700);

            // Act
            Invoice invoiceCopy = new Invoice(invoice.Number, DateTime.Today, invoice.Customer);

            // Assert
            var productsReferenceEquals = invoice.Details.Zip(invoiceCopy.Details, (original, copy) => ReferenceEquals(original.Product, copy.Product));

            productsReferenceEquals.All(x => x).Should().BeTrue();

        }

        private static Invoice CreateInvoice()
        {
            Customer customer = new Customer("John", "Smith");
            Product product1 = new Product("Keyboard", 250);
            Product product2 = new Product("Mouse", 150);

            Invoice invoice = new Invoice("FA 1", DateTime.Parse("2022-03-01"), customer);
            invoice.Details.Add(new InvoiceDetail(product1));
            invoice.Details.Add(new InvoiceDetail(product2, 3));

            return invoice;
        }
    }
}
