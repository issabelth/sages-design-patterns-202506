using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class SalesReport
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalSalesAmount { get; set; }

        public IEnumerable<ProductReportDetail> ProductDetails { get; set; } = new List<ProductReportDetail>();
        public IEnumerable<GenderReportDetail> GenderDetails { get; set; } = new List<GenderReportDetail>();


        public override string ToString()
        {
            string output = string.Empty;

            output += "------------------------------\n";

            output += $"{Title} {CreateDate}\n";
            output += $"Total Sales Amount: {TotalSalesAmount:c2}\n";

            output += "------------------------------\n";

            if (ProductDetails.Any())
            {
                output += "Total By Products:\n";
                foreach (var detail in ProductDetails)
                {
                    output += $"- {detail.Product.Name} {detail.Quantity} {detail.TotalAmount:c2}\n";
                }
            }

            if (GenderDetails.Any())
            {
                output += "Total By Gender:\n";
                foreach (var detail in GenderDetails)
                {
                    output += $"- {detail.Gender} {detail.Quantity} {detail.TotalAmount:c2}\n";
                }
            }

            return output;
        }
    }




}