using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleCommand : IRequest<Unit>
    {
        public Guid SaleId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<ModifySaleItem> Items { get; set; } = new();

        public class ModifySaleItem
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }
        }
    }
}
