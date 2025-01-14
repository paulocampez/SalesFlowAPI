using Ambev.DeveloperEvaluation.Application.Orders.Queries;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<GetOrdersResult>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrdersResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersAsync();

            return orders.Select(order => new GetOrdersResult
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString()
            }).ToList();
        }
    }
}
