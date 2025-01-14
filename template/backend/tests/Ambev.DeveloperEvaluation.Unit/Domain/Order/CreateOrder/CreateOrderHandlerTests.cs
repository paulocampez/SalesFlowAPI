using Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Orders
{
    public class CreateOrderHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly CreateOrderHandler _handler;

        public CreateOrderHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new CreateOrderHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateOrderAndReturnId()
        {
            // Arrange
            var command = new CreateOrderCommand
            {
                CustomerName = "John Doe",
                TotalAmount = 100,
                Status = Domain.Enums.OrderStatus.Pending
            };

            _orderRepositoryMock
                .Setup(repo => repo.CreateOrderAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            _orderRepositoryMock.Verify(repo => repo.CreateOrderAsync(It.IsAny<Order>()), Times.Once);
        }
    }
}
