using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdResult>
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
