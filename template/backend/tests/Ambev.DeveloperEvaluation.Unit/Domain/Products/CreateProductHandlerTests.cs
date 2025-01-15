using Ambev.DeveloperEvaluation.Application.Products.Commands;
using Ambev.DeveloperEvaluation.Application.Products.Handlers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Products
{
    public class CreateProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly CreateProductHandler _handler;

        public CreateProductHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new CreateProductHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateProductAndReturnId()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Name = "Product A",
                Price = 50
            };

            _productRepositoryMock
                .Setup(repo => repo.CreateProductAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Name != string.Empty);
            _productRepositoryMock.Verify(r => r.CreateProductAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}
