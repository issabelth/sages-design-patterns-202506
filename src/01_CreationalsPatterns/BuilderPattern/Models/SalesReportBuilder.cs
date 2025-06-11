using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Models;

public class Invoice
{
    public string InvoiceNumber { get; set; }
    public DateTime CreateOn { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public static decimal Tax { get; set; } = 0.23m;

    private Invoice()
    {
    }

    public static Invoice Create()
    {
        return new Invoice();
    }

    public void Print()
    {
        Console.WriteLine($"{InvoiceNumber}");
    }

    public static decimal GetTax()
    {
        return Tax;
    }
}


internal class SalesReportBuilder
{
    SalesReport salesReport;

    private IEnumerable<Order> _orders;

    public SalesReportBuilder(IEnumerable<Order> orders)
    {
        _orders = orders;
        salesReport = new SalesReport();
    }

    public SalesReportBuilder AddHeader(string title)
    {
        salesReport.Title = title;
        salesReport.CreateDate = DateTime.Now;
        salesReport.TotalSalesAmount = _orders.Sum(s => s.Amount);

        return this;
    }

    public SalesReportBuilder AddSectionProductDetails()
    {
        salesReport.ProductDetails = _orders
            .SelectMany(o => o.Details)
            .GroupBy(o => o.Product)
            .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

        return this;
    }

    public SalesReportBuilder AddSectionGenderDetails()
    {
        salesReport.GenderDetails = _orders
            .GroupBy(o => o.Customer.Gender)
            .Select(g => new GenderReportDetail(g.Key, g.Count(), g.Sum(p => p.Amount)));


        return this;
    }



    public SalesReport Build()
    {
        return salesReport;
    }

}
