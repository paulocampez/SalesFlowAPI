namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ItemCancelledEvent
    {
        public Guid SaleId { get; }
        public Guid ItemId { get; }
        public DateTime CancelledAt { get; }

        public ItemCancelledEvent(Guid saleId, Guid itemId, DateTime cancelledAt)
        {
            SaleId = saleId;
            ItemId = itemId;
            CancelledAt = cancelledAt;
        }
    }
}
