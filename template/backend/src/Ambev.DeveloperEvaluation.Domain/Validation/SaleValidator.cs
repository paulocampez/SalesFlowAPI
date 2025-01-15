using System;
using System.Linq;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public static class SaleValidator
    {
        public static void Validate(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20)
                    throw new Exception($"Cannot sell more than 20 items of {item.ProductName}");

                if (item.Quantity >= 10)
                {
                    item.Discount = item.Quantity * item.UnitPrice * 0.20m;
                }
                else if (item.Quantity >= 4)
                {
                    item.Discount = item.Quantity * item.UnitPrice * 0.10m;
                }
                else
                {
                    item.Discount = 0;
                }
            }

            sale.TotalAmount = sale.Items.Sum(i => i.TotalAmount);
        }
    }
}
