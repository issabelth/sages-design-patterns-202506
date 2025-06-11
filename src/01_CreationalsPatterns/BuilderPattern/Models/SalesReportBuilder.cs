using System;
using System.Collections.Generic;
using System.Linq;

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

// Leniwy budowniczy z zastosowaniem delegatów
internal class SalesReportBuilder
{
    private IEnumerable<Order> _orders;

    private List<Action<SalesReport>> _buildSteps = [];

    public SalesReportBuilder(IEnumerable<Order> orders)
    {
        _orders = orders;        
    }

    public SalesReportBuilder AddHeader(string title)
    {
        _buildSteps.Add(report => AddHeaderStep(report, title));

        return this;
    }

    private void AddHeaderStep(SalesReport salesReport, string title)
    {
        salesReport.Title = title;
        salesReport.CreateDate = DateTime.Now;
        salesReport.TotalSalesAmount = _orders.Sum(s => s.Amount);
    }

    public SalesReportBuilder AddSectionProductDetails()
    {
        _buildSteps.Add(report => AddSectionProductDetailsStep(report));

        return this;
    }

    private void AddSectionProductDetailsStep(SalesReport salesReport)
    {
        salesReport.ProductDetails = _orders
                    .SelectMany(o => o.Details)
                    .GroupBy(o => o.Product)
                    .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
    }

    public SalesReportBuilder AddSectionGenderDetails()
    {
        _buildSteps.Add(report => AddSectionGenderDetailsStep(report));

        return this;
    }

    private void AddSectionGenderDetailsStep(SalesReport salesReport)
    {
        salesReport.GenderDetails = _orders
            .GroupBy(o => o.Customer.Gender)
            .Select(g => new GenderReportDetail(g.Key, g.Count(), g.Sum(p => p.Amount)));
    }

    public SalesReport Build()
    {
        var salesReport = new SalesReport();

        foreach (var step in _buildSteps)
        {
            step(salesReport);
        }

        return salesReport;
    }

}
