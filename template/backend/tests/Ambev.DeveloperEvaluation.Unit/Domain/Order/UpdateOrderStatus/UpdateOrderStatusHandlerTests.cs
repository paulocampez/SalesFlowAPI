using Ambev.DeveloperEvaluation.Application.Orders.Commands.UpdateOrderStatus;

using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Orders
{
    public class UpdateOrderStatusHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly UpdateOrderStatusHandler _handler;

        public UpdateOrderStatusHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new UpdateOrderStatusHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldUpdateStatusAndReturnTrue()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var command = new UpdateOrderStatusCommand
            {
                OrderId = orderId,
                Status = "Completed"
            };

            var existingOrder = new Order
            {
                Id = orderId,
                Status = Domain.Enums.OrderStatus.Pending
            };

            _orderRepositoryMock
                .Setup(repo => repo.GetOrderByIdAsync(orderId))
                .ReturnsAsync(existingOrder);

            _orderRepositoryMock
                .Setup(repo => repo.UpdateOrderAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(MediatR.Unit.Value, result);
            Assert.Equal(Domain.Enums.OrderStatus.Completed, existingOrder.Status);
            _orderRepositoryMock.Verify(repo => repo.UpdateOrderAsync(existingOrder), Times.Once);
        }
    }
}
