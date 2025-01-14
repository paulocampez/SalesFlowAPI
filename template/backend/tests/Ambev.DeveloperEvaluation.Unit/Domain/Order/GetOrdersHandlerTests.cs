using Ambev.DeveloperEvaluation.Application.Orders.Handlers;
using Ambev.DeveloperEvaluation.Application.Orders.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Orders
{
    public class GetOrdersHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly GetOrdersHandler _handler;

        public GetOrdersHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new GetOrdersHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnOrdersList()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), CustomerName = "John Doe", TotalAmount = 100, Status = Domain.Enums.OrderStatus.Pending },
                new Order { Id = Guid.NewGuid(), CustomerName = "Jane Doe", TotalAmount = 200, Status = Domain.Enums.OrderStatus.Completed }
            };

            _orderRepositoryMock
                .Setup(repo => repo.GetOrdersAsync())
                .ReturnsAsync(orders);

            // Act
            var result = await _handler.Handle(new GetOrdersQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, o => o.CustomerName == "John Doe");
            Assert.Contains(result, o => o.CustomerName == "Jane Doe");
        }
    }
}
