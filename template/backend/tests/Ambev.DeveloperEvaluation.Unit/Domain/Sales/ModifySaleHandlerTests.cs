using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Application.Sales.ModifySale;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Application.Tests.Sales.ModifySale
{
    public class ModifySaleHandlerTests
    {
        private readonly Mock<ILogger<ModifySaleHandler>> _loggerMock;
        private readonly Mock<ILogger<SaleEventLogger>> _eventLoggerLoggerMock;
        private readonly SaleEventLogger _eventLogger;
        private readonly ModifySaleHandler _handler;

        public ModifySaleHandlerTests()
        {
            _loggerMock = new Mock<ILogger<ModifySaleHandler>>();
            _eventLoggerLoggerMock = new Mock<ILogger<SaleEventLogger>>();
            _eventLogger = new SaleEventLogger(_eventLoggerLoggerMock.Object);
            _handler = new ModifySaleHandler(_loggerMock.Object, _eventLogger);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new ModifySaleCommand
            {
                Customer = "", // Inválido
                Items = new List<ModifySaleCommand.ModifySaleItem>() // Nenhum item
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _handler.Handle(command, CancellationToken.None));

            Assert.Contains("Customer is required", exception.Message);
        }
    }
}
