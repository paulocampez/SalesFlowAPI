using System;

namespace Ambev.DeveloperEvaluation.Application.Orders.Queries
{
    public class GetOrdersResult
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
