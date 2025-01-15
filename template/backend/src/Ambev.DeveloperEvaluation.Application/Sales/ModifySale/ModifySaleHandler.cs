using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleHandler : IRequestHandler<ModifySaleCommand, Unit>
    {
        private readonly ILogger<ModifySaleHandler> _logger;
        private readonly SaleEventLogger _eventLogger;

        public ModifySaleHandler(ILogger<ModifySaleHandler> logger, SaleEventLogger eventLogger)
        {
            _logger = logger;
            _eventLogger = eventLogger;
        }

        public async Task<Unit> Handle(ModifySaleCommand request, CancellationToken cancellationToken)
        {
            // Simulate modification logic
            _logger.LogInformation("Modifying sale {SaleId}", request.SaleId);
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Customer))
                throw new ArgumentException("Customer is required.", nameof(request.Customer));

            if (request.Items == null || !request.Items.Any())
                throw new ArgumentException("At least one item is required.", nameof(request.Items));

            foreach (var item in request.Items)
            {
                if (item.Quantity <= 0)
                    throw new ArgumentException("Item quantity must be greater than zero.", nameof(item.Quantity));

                if (item.UnitPrice <= 0)
                    throw new ArgumentException("Item unit price must be greater than zero.", nameof(item.UnitPrice));
            }
            // Here, update the database or in-memory storage

            // Log the SaleModifiedEvent
            var saleEvent = new SaleModifiedEvent(request.SaleId, DateTime.UtcNow);
            _eventLogger.LogSaleModified(saleEvent);

            return Unit.Value;
        }
    }
}
