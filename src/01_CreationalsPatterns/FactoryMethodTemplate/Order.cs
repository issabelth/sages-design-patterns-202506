using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodTemplate
{
    public class Order
    {
        public decimal Amount { get; private set; }
        public decimal Percentage { get; private set; }
        public decimal DiscountedAmount
        {
            get
            {
                return Amount * (1 - Percentage);
            }
        }

        public Order(decimal amount, decimal percentage)
        {
            Amount = amount;
            Percentage = percentage;
        }
    }

}
