using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
                throw new Exception("Order not found.");

            return new GetOrderByIdResult
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                Products = order.Products.Select(p => p.Name).ToList(),
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString()
            };
        }
    }
}
