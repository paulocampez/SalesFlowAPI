using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleEventLogger
    {
        private readonly ILogger<SaleEventLogger> _logger;

        public SaleEventLogger()
        {

        }
        public SaleEventLogger(ILogger<SaleEventLogger> logger)
        {
            _logger = logger;
        }

        public void LogSaleCreated(SaleCreatedEvent saleEvent)
        {
            _logger.LogInformation("Sale created: SaleId={SaleId}, CreatedAt={CreatedAt}",
                saleEvent.SaleId, saleEvent.CreatedAt);
        }

        public void LogSaleModified(SaleModifiedEvent saleEvent)
        {
            _logger.LogInformation("Sale modified: SaleId={SaleId}, ModifiedAt={ModifiedAt}",
                saleEvent.SaleId, saleEvent.ModifiedAt);
        }

        public void LogSaleCancelled(SaleCancelledEvent saleEvent)
        {
            _logger.LogInformation("Sale cancelled: SaleId={SaleId}, CancelledAt={CancelledAt}",
                saleEvent.SaleId, saleEvent.CancelledAt);
        }

        public void LogItemCancelled(ItemCancelledEvent itemEvent)
        {
            _logger.LogInformation("Item cancelled: SaleId={SaleId}, ItemId={ItemId}, CancelledAt={CancelledAt}",
                itemEvent.SaleId, itemEvent.ItemId, itemEvent.CancelledAt);
        }
    }
}
