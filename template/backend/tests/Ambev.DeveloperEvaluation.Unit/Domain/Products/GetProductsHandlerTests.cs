using Ambev.DeveloperEvaluation.Application.Products.Handlers;
using Ambev.DeveloperEvaluation.Application.Products.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Products
{
    public class GetProductsHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly GetProductsHandler _handler;

        public GetProductsHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new GetProductsHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnProductsList()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product A", Price = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Product B", Price = 75 }
            };

            _productRepositoryMock
                .Setup(repo => repo.GetProductsAsync())
                .ReturnsAsync(products);

            // Act
            var result = await _handler.Handle(new GetProductsQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.Name == "Product A");
            Assert.Contains(result, p => p.Name == "Product B");
        }
    }
}
