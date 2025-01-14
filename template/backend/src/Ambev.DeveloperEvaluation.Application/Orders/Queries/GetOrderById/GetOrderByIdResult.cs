using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdResult
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<string> Products { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
