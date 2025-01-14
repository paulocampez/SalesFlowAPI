using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder

{

    public class CreateOrderCommand : IRequest<Guid>

    {
        public string CustomerName { get; set; } = string.Empty;
        public List<Guid> ProductIds { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}
