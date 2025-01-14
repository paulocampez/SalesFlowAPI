using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
                throw new Exception("Order not found.");

            order.Status = Enum.Parse<OrderStatus>(request.Status, true);
            await _orderRepository.UpdateOrderAsync(order);

            return Unit.Value;
        }
    }
}
