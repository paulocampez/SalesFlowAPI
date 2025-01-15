using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ILogger<CreateSaleHandler> _logger;
        private readonly SaleEventLogger _eventLogger;

        public CreateSaleHandler(ILogger<CreateSaleHandler> logger, SaleEventLogger eventLogger)
        {
            _logger = logger;
            _eventLogger = eventLogger;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            // Simulate creation logic
            var saleId = Guid.NewGuid();
            var createdAt = DateTime.UtcNow;

            // Log the SaleCreatedEvent
            var saleEvent = new SaleCreatedEvent(saleId, createdAt);
            _eventLogger.LogSaleCreated(saleEvent);

            return new CreateSaleResult
            {
                SaleId = saleId,
                CreatedAt = createdAt
            };
        }
    }
}
